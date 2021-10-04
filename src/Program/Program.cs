using System;
using RoleplayGame;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            TestVPHealing();
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");
        }

        public static void TestVPHealing()
        {
            Hero knight = new Knight("Gilberto");
            Enemy darkArcher = new DarkArcher("Rabanito el Malito");

            List<Hero> heroes = new List<Hero>();
            heroes.Add(knight);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(darkArcher); // VP = 1

            Encounter encounter = new Encounter(heroes, enemies);
            encounter.DoEncounter(); // knight.VP = 1
            int notExpected = 100;
            System.Console.WriteLine(knight.Health);

            knight.AddVP(3); // knight.VP = 4
            darkArcher.Cure();
            enemies.Add(darkArcher);
            encounter = new Encounter(heroes, enemies);
            encounter.DoEncounter(); // knight.VP = 0;
            int expected = 100;
            System.Console.WriteLine(knight.Health);
            expected = 0;
            System.Console.WriteLine(knight.VP);
        }
    }
}
