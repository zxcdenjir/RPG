class Rogue(string className, double health, double mana, int level, string name, int experience, double baseDamage, bool stealth)
    : Character(className, health, mana, level, name, experience, baseDamage)
{
    public bool Stealth = stealth;

    override public void Attack(Character enemy)
    {
        Console.WriteLine($"{ClassName} {Name} атакует {enemy.Name} клинком в {BaseDamage:F2} единиц");
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
            if (Stealth)
            {
                amount -= amount * 0.05;
                Console.WriteLine($"{ClassName} {Name} уклоняется от удара в {Math.Round(amount, 2):F2} единиц");
                TakeDamage(Math.Round(amount, 2));
            }
            else
            {
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
            int hitCount = random.Next(2, 4);
            double totalDamage = 0;
            Console.WriteLine($"{ClassName} {Name} использует 'Phantom Barrage' и наносит серию ударов:");
            for (int i = 1; i <= hitCount; i++)
            {
                double damage = Math.Round(BaseDamage * 1.2, 2);
                totalDamage += damage;
                Console.WriteLine($"  Удар {i}: {damage:F2} единиц урона");
                enemy.Defend(damage);
            }
            Console.WriteLine($"Общий нанесенный урон: {totalDamage:F2} единиц");
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }

    override public void Move()
    {
        Console.WriteLine($"{ClassName} {Name} двигается с повышенной скоростью 380 единиц");
    }

    virtual public void Backstab(Character enemy)
    {
        Mana -= 95;
        if (Mana < 0)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования доп. способности");
            return;
        }
        double damage = Math.Round(BaseDamage * 1.5, 2);
        Console.WriteLine($"{ClassName} {Name} наносит удар {enemy.Name} в спину в {damage:F2} единиц");
        enemy.Defend(damage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }
}

class Assassin(string className, double health, double mana, int level, string name, int experience, int baseDamage, bool stealth, int poisonDamage)
    : Rogue(className, health, mana, level, name, experience, baseDamage, stealth)
{
    public double PoisonDamage = poisonDamage;

    override public void Attack(Character enemy)
    {
        double damage;
        bool isCritical = random.Next(0, 100) < 10;
        if (isCritical)
        {
            damage = Math.Round(BaseDamage * 2.5, 2);
            Console.WriteLine($"{ClassName} {Name} наносит критический удар в {damage:F2} единиц");
        }
        else
        {
            damage = BaseDamage;
            Console.WriteLine($"{ClassName} {Name} атакует {enemy.Name} в {damage:F2} единиц");
        }
        enemy.Defend(damage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }

    override public void UseAbility(Character enemy)
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
            double damage = Math.Round(BaseDamage * 3, 2);
            Console.WriteLine($"{ClassName} {Name} использует 'Shadow Strike', гарантируя критический удар в {damage:F2} единиц");
            enemy.Defend(damage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }

    public override void Backstab(Character enemy)
    {
        Mana -= 95;
        if (Mana < 0)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования доп. способности");
            return;
        }
        double poisonChance = random.NextDouble();
        double baseBackstab = Math.Round(BaseDamage * 1.5, 2);
        if (poisonChance <= 0.60)
        {
            Console.WriteLine($"{ClassName} {Name} наносит удар {enemy.Name} в спину в {baseBackstab:F2} единиц");
            enemy.Defend(baseBackstab);
        }
        else
        {
            double totalDamage = Math.Round(baseBackstab + PoisonDamage, 2);
            Console.WriteLine($"{ClassName} {Name} наносит удар {enemy.Name} в спину с дополнительным уроном от яда в {totalDamage:F2} единиц");
            enemy.Defend(totalDamage);
        }
    }
}

class Ranger(string className, double health, double mana, int level, string name, int experience, int baseDamage, bool stealth, double archerySkill)
    : Rogue(className, health, mana, level, name, experience, baseDamage, stealth)
{
    public double ArcherySkill = archerySkill;

    override public void Attack(Character enemy)
    {
        double hitChance = random.NextDouble();
        if (hitChance < ArcherySkill)
        {
            Console.WriteLine($"{ClassName} {Name} атакует стрелой в {BaseDamage:F2} единиц");
            enemy.Defend(BaseDamage);
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
        else
        {
            Console.WriteLine($"{ClassName} {Name} промахнулся");
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
            Console.WriteLine($"{ClassName} {Name} использует 'Rain of Arrows', нанося серию быстрых выстрелов");
            for (int i = 0; i < 3; i++)
            {
                double damage = Math.Round(BaseDamage * 1.2, 2);
                enemy.Defend(damage);
            }
            if (enemy.Health <= 0)
            {
                int xpReward = 50 + (enemy.Level * 10);
                GainExperience(xpReward);
            }
        }
    }
    override public void Backstab(Character enemy)
    {
        Mana -= 95;
        if (Mana < 0)
        {
            Mana = 0;
            Console.WriteLine($"У {Name} недостаточно маны для использования доп. способности");
            return;
        }
        double damage = Math.Round(BaseDamage * 1.5, 2);
        Console.WriteLine($"{ClassName} {Name} выстреливает в спину {enemy.Name} в {damage:F2} единиц");
        enemy.Defend(damage);
        if (enemy.Health <= 0)
        {
            int xpReward = 50 + (enemy.Level * 10);
            GainExperience(xpReward);
        }
    }
}
