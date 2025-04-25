class Warrior(string className, double health, double mana, int level, string name, int experience, double baseDamage, double armor)
    : Character(className, health, mana, level, name, experience, baseDamage)
{
    public double Armor = armor;

    override public void Attack(Character enemy)
    {
        Console.WriteLine($"{ClassName} {Name} атакует {enemy.Name} мечом в {BaseDamage:F2} единиц");
        enemy.Defend(BaseDamage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }

    override public void Defend(double amount)
    {
        if (Health > 0)
        {
            Console.WriteLine($"{ClassName} {Name} защищается щитом");
            TakeDamage(Math.Round(amount * 100 / (100 + Armor), 2));
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
            double damage = Math.Round(BaseDamage * 1.5, 2);
            Console.WriteLine($"{ClassName} {Name} использует 'Rage Strike', нанося {damage:F2} урона, игнорируя броню");
            enemy.TakeDamage(damage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }

    virtual public void BerserkMode(Character enemy)
    {
        double selfDamage = Math.Round(MaxHealth * 0.10, 2);
        Health -= selfDamage;
        if (Health <= 0)
        {
            Health = 1;
        }
        double damage = Math.Round((BaseDamage + (enemy.MaxHealth * 0.05)) * 2, 2);
        Console.WriteLine($"{ClassName} {Name} переходит в режим берсерка и наносит два удара с дополнительным уроном суммой {damage:F2} единиц");
        enemy.Defend(damage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }

    public override void TakeDamage(double amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
            Console.WriteLine($"{Name} умер");
        }
        else
        {
            Console.WriteLine($"{Name} получает уменьшенный урон в размере {Math.Round(amount, 2):F2}");
        }
    }
}

class Paladin(string className, double health, double mana, int level, string name, int experience, int baseDamage, double armor, double holyPower)
    : Warrior(className, health, mana, level, name, experience, baseDamage, armor)
{
    public double HolyPower = holyPower;

    override public void UseAbility(Character enemy)
    {
        double manaCost = Math.Round(MaxMana * 0.25, 2);
        if (Mana < manaCost)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования доп. способности");
        }
        else
        {
            Mana -= manaCost;
            double healAmount = Math.Round(MaxHealth * HolyPower, 2);
            Console.WriteLine($"{ClassName} {Name} излечивается на {healAmount:F2}");
            Health += healAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }
}

class Berserker(string className, double health, double mana, int level, string name, int experience, int baseDamage, double armor, bool rage)
    : Warrior(className, health, mana, level, name, experience, baseDamage, armor)
{
    public bool Rage = rage;

    override public void Attack(Character enemy)
    {
        if (Health < 0.3 * MaxHealth)
        {
            Rage = true;
            double attackDamage = Math.Round(BaseDamage * 2, 2);
            Console.WriteLine($"{ClassName} {Name} атакует мечом {enemy.Name} и наносит двойной урон в {attackDamage:F2} единиц");
            enemy.Defend(BaseDamage * 2);
        }
        else
        {
            Rage = false;
            Console.WriteLine($"{ClassName} {Name} атакует мечом {enemy.Name} в {BaseDamage:F2} единиц");
            enemy.Defend(BaseDamage);
        }
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }

    public override void UseAbility(Character enemy)
    {
        double manaCost = Math.Round(MaxMana * 0.25, 2);
        if (Mana < manaCost)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования ультимейта");
        }
        else
        {
            Mana -= manaCost;
            Console.WriteLine($"{ClassName} {Name} использует 'Berserk Fury' и совершает серию атак");
            double damage = Math.Round(BaseDamage * 2, 2);
            enemy.Defend(damage);
            enemy.Defend(damage);
            double selfDamage = Math.Round(MaxHealth * 0.05, 2);
            TakeDamage(selfDamage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
}
