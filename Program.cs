class Program
{
    static void Main()
    {
        List<Character> characters =
        [
            new Warrior("Воин", 626, 267, 1, "Sven", 0, 62, 3.0),
            new Mage("Маг", 538, 315, 1, "Invoker", 0, 41, 1.6),
            new Rogue("Разбойник", 538, 315, 1, "Bounty Hunter", 0, 62, true),
            new Paladin("Паладин", 604, 267, 1, "Omniknight", 0, 50, 2, 0.8),
            new Berserker("Берсерк", 582, 231, 1, "Troll Warlord", 0, 55, 3, false),
            new Necromancer("Некромант", 516, 351, 1, "Necrophos", 0, 53, 1.1, 2),
            new Elementalist("Элементалист", 582, 351, 1, "Storm Spirit", 0, 57, 1.5, "Electric"),
            new Assassin("Ассассин", 538, 255, 1, "Phantom Assassin", 0, 58, false, 20),
            new Ranger("Лучник", 472, 255, 1, "Drow Ranger", 0, 58, false, 0.9),
            //new Warrior("Воин", 670, 291, 1, "Axe", 0, 60, 3.3),
            //new Mage("Маг", 494, 291, 1, "Crystal Maiden", 0, 51, 1.35),
            //new Rogue("Разбойник", 516, 243, 1, "Riki", 0, 56, true),
            //new Paladin("Паладин", 604, 291, 1, "Abaddon", 0, 76, 2.8, 0.5),
            //new Berserker("Берсерк", 626, 0, 1, "Huskar", 0, 49, 2.7, false),
            //new Necromancer("Некромант", 560, 387, 1, "Lich", 0, 59, 1.2, 3),
            //new Elementalist("Элементалист", 604, 315, 1, "Ember Spirit", 0, 59, 1.4, "Fire"),
            //new Assassin("Ассассин", 626, 315, 1, "Templar Assassin", 0, 59, true, 25),
            //new Ranger("Лучник", 516, 291, 1, "Windranger", 0, 73, false, 0.8)
        ];

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Вывести всех персонажей");
            Console.WriteLine("2. Выбрать персонажа");
            Console.WriteLine("3. Вылечить всех персонажей");
            Console.WriteLine("4. Выход");

            int choice = IntInput("Выберите действие: ", 1, 4);

            switch (choice)
            {
                case 1:
                    PrintAllHeroes(characters);
                    break;
                case 2:
                    Console.Write("Введите имя персонажа: ");
                    string hero_name = Console.ReadLine();
                    Character? hero = null;
                    foreach (Character c in characters)
                    {
                        if (c.Name == hero_name)
                        {
                            hero = c;
                            break;
                        }
                    }
                    if (hero != null)
                    {
                        if (hero.Health <= 0)
                        {
                            Console.WriteLine("Персонаж мертв");
                            break;
                        }
                        Console.WriteLine($"Вы выбрали персонажа: {hero.Name}");

                        Console.Write("Введите имя вражеского персонажа: ");
                        string enemy_name = Console.ReadLine();

                        if (enemy_name == hero_name)
                        {
                            Console.WriteLine("Нельзя выбрать того же самого персонажа");
                            break;
                        }

                        Character? enemy = null;
                        foreach (Character c in characters)
                        {
                            if (c.Name == enemy_name)
                            {
                                enemy = c;
                                break;
                            }
                        }
                        if (enemy != null)
                        {
                            if (enemy.Health <= 0)
                            {
                                Console.WriteLine("Персонаж мертв.");
                                break;
                            }
                            int action;
                            switch (hero)
                            {
                                case Warrior warrior when (warrior is not Paladin) && (warrior is not Berserker):
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Перейти в режим берсерка");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            warrior.Attack(enemy);
                                            break;
                                        case 2:
                                            warrior.BerserkMode(enemy);
                                            break;
                                        case 3:
                                            warrior.Move();
                                            break;
                                        case 4:
                                            warrior.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Paladin paladin:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Перейти в режим берсерка");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            paladin.Attack(enemy);
                                            break;
                                        case 2:
                                            paladin.BerserkMode(enemy);
                                            break;
                                        case 3:
                                            paladin.Move();
                                            break;
                                        case 4:
                                            paladin.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Berserker berserker:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Перейти в режим берсерка");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            berserker.Attack(enemy);
                                            break;
                                        case 2:
                                            berserker.BerserkMode(enemy);
                                            break;
                                        case 3:
                                            berserker.Move();
                                            break;
                                        case 4:
                                            berserker.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Mage mage when (mage is not Necromancer) && (mage is not Elementalist):
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Медитировать");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            mage.Attack(enemy);
                                            break;
                                        case 2:
                                            mage.Mediate();
                                            break;
                                        case 3:
                                            mage.Move();
                                            break;
                                        case 4:
                                            mage.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Necromancer necromancer:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Медитировать");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            necromancer.Attack(enemy);
                                            break;
                                        case 2:
                                            necromancer.Mediate();
                                            break;
                                        case 3:
                                            necromancer.Move();
                                            break;
                                        case 4:
                                            necromancer.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Elementalist elementalist:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Медитировать");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            elementalist.Attack(enemy);
                                            break;
                                        case 2:
                                            elementalist.Mediate();
                                            break;
                                        case 3:
                                            elementalist.Move();
                                            break;
                                        case 4:
                                            elementalist.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Rogue rogue when (rogue is not Assassin) && (rogue is not Ranger):
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Удар в спину");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            rogue.Attack(enemy);
                                            break;
                                        case 2:
                                            rogue.Backstab(enemy);
                                            break;
                                        case 3:
                                            rogue.Move();
                                            break;
                                        case 4:
                                            rogue.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Assassin assassin:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Нанести удар в спину");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            assassin.Attack(enemy);
                                            break;
                                        case 2:
                                            assassin.Backstab(enemy);
                                            break;
                                        case 3:
                                            assassin.Move();
                                            break;
                                        case 4:
                                            assassin.UseAbility(enemy);
                                            break;
                                    }
                                    break;

                                case Ranger ranger:
                                    Console.WriteLine("1. Атаковать");
                                    Console.WriteLine("2. Нанести выстрел в спину");
                                    Console.WriteLine("3. Переместиться");
                                    Console.WriteLine("4. Использовать способность");
                                    action = IntInput("Выберите действие: ", 1, 4);
                                    switch (action)
                                    {
                                        case 1:
                                            ranger.Attack(enemy);
                                            break;
                                        case 2:
                                            ranger.Backstab(enemy);
                                            break;
                                        case 3:
                                            ranger.Move();
                                            break;
                                        case 4:
                                            ranger.UseAbility(enemy);
                                            break;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Персонаж не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Персонаж не найден.");
                    }
                    break;
                case 3:
                    foreach (Character c in characters)
                    {
                        c.Health = c.MaxHealth;
                    }
                    Console.WriteLine("Все персонажи вылечены");
                    break;
                case 4:
                    return;
            }
        }
    }

    private static void PrintAllHeroes(List<Character> characters)
    {
        foreach (Character character in characters)
        {
            Console.Write($"Имя: {character.Name,-16} │ Здоровье: {Math.Round(character.Health, 2),-7} │ Мана: {Math.Round(character.Mana, 2),-6} │ Уровень: {character.Level,-2} │ Опыт: {character.CurrentExperience,-5} │ Базовый урон: {Math.Round(character.BaseDamage, 2),-6} │ ");
            switch (character)
            {
                case Warrior warrior when warrior is not Paladin && warrior is not Berserker:
                    Console.WriteLine($"Тип: {"Воин",-12} │ Броня: {Math.Round(warrior.Armor, 2),-14}");
                    break;
                case Paladin paladin:
                    Console.WriteLine($"Тип: {"Паладин",-12} │ Броня: {Math.Round(paladin.Armor, 2),-14} │ Святая сила: {Math.Round(paladin.HolyPower, 2),-4}");
                    break;
                case Berserker berserker:
                    Console.WriteLine($"Тип: {"Берсерк",-12} │ Броня: {Math.Round(berserker.Armor, 2),-14} │ Ярость: {berserker.Rage,-5}");
                    break;
                case Mage mage when mage is not Necromancer && mage is not Elementalist:
                    Console.WriteLine($"Тип: {"Маг",-12} │ Сила заклинаний: {Math.Round(mage.SpellPower, 2),-4}");
                    break;
                case Necromancer necromancer:
                    Console.WriteLine($"Тип: {"Некромант",-12} │ Сила заклинаний: {Math.Round(necromancer.SpellPower, 2),-4} │ Количество нежити: {necromancer.UndeadMinions,-2}");
                    break;
                case Elementalist elementalist:
                    Console.WriteLine($"Тип: {"Элементалист",-12} │ Сила заклинаний: {Math.Round(elementalist.SpellPower, 2),-4} │ Элемент: {elementalist.ElementType,-8}");
                    break;
                case Rogue rogue when rogue is not Assassin && rogue is not Ranger:
                    Console.WriteLine($"Тип: {"Разбойник",-12} │ Стелс: {rogue.Stealth,-14}");
                    break;
                case Assassin assassin:
                    Console.WriteLine($"Тип: {"Ассассин",-12} │ Ядовитый урон: {Math.Round(assassin.PoisonDamage, 2),-6}");
                    break;
                case Ranger ranger:
                    Console.WriteLine($"Тип: {"Лучник",-12} │ Навык стрельбы: {Math.Round(ranger.ArcherySkill, 2),-5}");
                    break;
            }
        }
    }


    private static int IntInput(string text, int min, int max)
    {
        int value;
        bool isCorrect;
        do
        {
            Console.Write(text);
            isCorrect = int.TryParse(Console.ReadLine(), out value);
            if (!isCorrect || value < min || value > max)
                Console.WriteLine($"Некорректный ввод. Пожалуйста, введите число от {min} до {max}.");
        } while (!isCorrect || value < min || value > max);
        return value;
    }
}
