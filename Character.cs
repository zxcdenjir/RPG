abstract class Character(string className, double health, double mana, int level, string name, int experience, double baseDamage)
{
    public static Random random = new();

    public string ClassName = className;
    public int Level = level;
    public string Name = name;
    public int CurrentExperience = experience;
    public double Health = health;
    public double MaxHealth = health;
    public double Mana = mana;
    public double MaxMana = mana;
    public double BaseDamage = baseDamage;
    public int ExperienceForNextLevel { get { return 100 + ((Level - 1) * 50); } }

    abstract public void Attack(Character enemy);
    abstract public void Defend(double amount);
    abstract public void UseAbility(Character enemy);
    virtual public void Move() { Console.WriteLine($"{ClassName} {Name} двигается с обычной скоростью 330 единиц"); }
    virtual public void TakeDamage(double amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
            Console.WriteLine($"{ClassName} {Name} умер");
        }
        else
            Console.WriteLine($"{ClassName} {Name} получает урон в размере {amount} единиц");
    }
    virtual public void GainExperience(int amount)
    {
        CurrentExperience += amount;
        Console.WriteLine($"{Name} получает {amount} опыта, текущее значение: {CurrentExperience}/{ExperienceForNextLevel}");

        while (CurrentExperience >= ExperienceForNextLevel)
        {
            CurrentExperience -= ExperienceForNextLevel;
            LevelUp();
        }
    }
    virtual public void LevelUp()
    {
        Level++;

        MaxHealth += Math.Round(MaxHealth * 0.1 + 20,2);
        MaxMana += Math.Round(MaxMana * 0.12 + 15,2);
        BaseDamage += Math.Round(BaseDamage * 0.6 + 5, 2);

        Health = MaxHealth;
        Mana = MaxMana;

        Console.WriteLine($"{Name} достиг {Level} уровня!");
    }
}
