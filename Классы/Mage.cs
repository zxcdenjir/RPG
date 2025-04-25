class Mage(string className, double health, double mana, int level, string name, int experience, double baseDamage, double spellPower)
    : Character(className, health, mana, level, name, experience, baseDamage)
{
    public double SpellPower = spellPower;

    override public void Attack(Character enemy)
    {
        double manaCost = 10;
        if (Mana < manaCost)
        {
            Console.WriteLine($"У {Name} недостаточно маны для атаки");
        }
        else
        {
            Mana -= manaCost;
            double damage = Math.Round(BaseDamage * SpellPower, 2);
            Console.WriteLine($"{ClassName} {Name} атакует {enemy.Name} заклинанием в {damage:F2} единиц");
            enemy.Defend(damage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
    override public void Defend(double amount)
    {
        if (Health > 0)
        {
            if (Mana > 0)
            {
                double shield_strength = Mana / MaxMana;
                Mana -= amount;
                amount -= amount * (shield_strength * 0.2);
                Console.WriteLine($"{ClassName} {Name} блокирует магическим щитом {Math.Round(shield_strength * 0.2 * 100, 2):F2}% урона");
                TakeDamage(Math.Round(amount, 2));
            }
            else
            {
                Console.WriteLine($"У {Name} недостаточно маны для защиты");
                TakeDamage(amount);
            }
        }
    }
    override public void UseAbility(Character enemy)
    {
        double manaCost = Math.Round(MaxMana * 0.30, 2);
        if (Mana < manaCost)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования ультимейта");
        }
        else
        {
            Mana -= manaCost;
            double damage = Math.Round(BaseDamage * SpellPower * 2, 2);
            Console.WriteLine($"{ClassName} {Name} использует 'Arcane Blast', нанося {damage:F2} урона");
            enemy.Defend(damage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
    virtual public void Mediate()
    {
        double regen = Math.Round(MaxMana * 0.5, 2);
        Mana += regen;
        if (Mana > MaxMana)
            Mana = MaxMana;
        Console.WriteLine($"{ClassName} {Name} медитирует и регенерирует ману на {regen:F2} единиц");
    }
}

class Necromancer(string className, double health, double mana, int level, string name, int experience, int baseDamage, double spellPower, int undeadMinions)
    : Mage(className, health, mana, level, name, experience, baseDamage, spellPower)
{
    public int UndeadMinions = undeadMinions;

    public override void Attack(Character enemy)
    {
        double cost = Math.Round(MaxMana * 0.1, 2);
        Mana -= cost;
        if (Mana <= 0)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для атаки");
        }
        else
        {
            double damage = Math.Round(BaseDamage * SpellPower + (BaseDamage * UndeadMinions / 10.0), 2);
            Console.WriteLine($"{ClassName} {Name} атакует {enemy.Name} заклинанием в {damage:F2} единиц");
            enemy.Defend(Math.Round(BaseDamage * SpellPower, 2));
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
    override public void UseAbility(Character enemy)
    {
        double manaCost = Math.Round(MaxMana * 0.20, 2);
        if (Mana < manaCost)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования ультимейта");
        }
        else
        {
            Mana -= manaCost;
            UndeadMinions += 1;
            Console.WriteLine($"{ClassName} {Name} призывает существ в количестве {UndeadMinions}");
        }
    }
}

class Elementalist(string className, double health, double mana, int level, string name, int experience, int baseDamage, double spellPower, string elementType)
    : Mage(className, health, mana, level, name, experience, baseDamage, spellPower)
{
    public string ElementType = elementType;
    override public void Attack(Character enemy)
    {
        double damage = Math.Round(BaseDamage * SpellPower, 2);
        Console.WriteLine($"{ClassName} {Name} атакует заклинанием стихии {ElementType} в размере {damage:F2}");
        enemy.TakeDamage(damage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }
    override public void UseAbility(Character enemy)
    {
        double manaCost = Math.Round(MaxMana * 0.30, 2);
        if (Mana < manaCost)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования ультимейта");
        }
        else
        {
            Mana -= manaCost;
            double damage = Math.Round(BaseDamage * SpellPower * 2.5, 2);
            Console.WriteLine($"{ClassName} {Name} вызывает 'Elemental Surge', нанося {damage:F2} урона стихией {ElementType}");
            enemy.Defend(damage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
}
