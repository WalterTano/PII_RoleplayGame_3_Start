using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using RoleplayGame;

namespace Test.Library
{
    public class Tests
    {

        // Lucas Giffuni
        [Test]
        public void TestCharacter()
        {
            Character c = new Knight("Gilberto");
            Assert.NotNull(c);
        }

        [Test]
        public void TestName()
        {
            Character c = new Knight("Gilberto");
            string expected = "Gilberto";
            Assert.AreEqual(expected, c.Name);
        }

        [Test]
        public void TestHealth()
        {
            Character c = new Knight("Gilberto");
            int expected = 100;
            Assert.AreEqual(expected, c.Health);
        }

        public void TestAttackValue()
        {
            Character c = new Knight("Gilberto");
            int expected = 20;
            Assert.AreEqual(expected, c.AttackValue);
        }

        [Test]
        public void TestDefenseValue()
        {
            Character c = new Knight("Gilberto");
            int expected = 39;
            Assert.AreEqual(expected, c.DefenseValue);
        }

        // Walter Taño
        [Test]
        public void TestAttack()
        {
            Character knight = new Knight("Gilberto"); // att = 20
            Character dwarf = new Dwarf("Silva"); // def = 18
            dwarf.ReceiveAttack(knight.AttackValue);
            int expected = 98; // 100 = 2
            Assert.AreEqual(expected, dwarf.Health);
        }

        [Test]
        public void TestAttackWithItems()
        {
            Character knight = new Knight("Gilberto"); // att = 20
            Character dwarf = new Dwarf("Silva"); // def = 18
            Item axe = new Axe(); // att = 25
            knight.AddItem(axe); // att = 20 + 25

            int expected = 45;
            Assert.AreEqual(expected, knight.AttackValue);

            dwarf.ReceiveAttack(knight.AttackValue);

            expected = 73; // 100 - (45 - 18)
            Assert.AreEqual(expected, dwarf.Health);

            Item armor = new Armor(); // def = 25
            dwarf.AddItem(armor); // def = 18 + 25 = 43
            dwarf.ReceiveAttack(knight.AttackValue);

            expected = 71; // 73 - (45 - 43)
            Assert.AreEqual(expected, dwarf.Health);
        }

        //ezequiel
        [Test]
        public void TestRemoveItem()
        {
            Character knight = new Knight("Gilberto"); // att = 20
            Item axe = new Axe(); // att = 25
            knight.AddItem(axe); // att = 20 + 25 = 45

            int expected = 45;
            Assert.AreEqual(expected, knight.AttackValue);

            knight.RemoveItem(axe);
            expected = 20;
            Assert.AreEqual(expected, knight.AttackValue);
        }

        public Encounter CreateEncounter()
        {
            Hero knight = new Knight("Gilberto");
            Hero dwarf = new Dwarf("Silva");
            Enemy darkArcher = new DarkArcher("Rabanito el Malito");
            Enemy darkWizard = new DarkWizard("Tom Riddle");
            Enemy darkDwarf = new DarkDwarf("Gervasio");

            List<Hero> heroes = new List<Hero>();
            heroes.Add(knight);
            heroes.Add(dwarf);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(darkArcher);
            enemies.Add(darkWizard);
            enemies.Add(darkDwarf);

            Encounter encounter = new Encounter(heroes, enemies);
            return encounter;
        }

        [Test]
        public void TestEncounter()
        {
            Assert.IsNotNull(this.CreateEncounter());
        }

        [Test]
        public void TestDoEncounter()
        {
            Encounter encounter = this.CreateEncounter();
            encounter.DoEncounter();
            int expected = 0;
            if (encounter.Heroes.Count > 0)
            {
                Assert.AreEqual(expected, encounter.Enemies.Count);
            }
            else
            {
                Assert.AreEqual(expected, encounter.Heroes.Count);
            }
        }

        [Test]
        public void TestVP()
        {
            Hero knight = new Knight("Gilberto");
            Enemy darkArcher = new DarkArcher("Rabanito el Malito");

            List<Hero> heroes = new List<Hero>();
            heroes.Add(knight);

            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(darkArcher); // VP = 1

            Encounter encounter = new Encounter(heroes, enemies);
            encounter.DoEncounter();
            int expected = 1;
            Assert.AreEqual(expected, knight.VP);
        }

        [Test]
        public void TestVPHealing()
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
            Assert.AreNotEqual(notExpected, knight.Health);

            knight.AddVP(3); // knight.VP = 4
            darkArcher.Cure();
            enemies.Add(darkArcher);
            encounter = new Encounter(heroes, enemies);
            encounter.DoEncounter(); // knight.VP = 0;
            int expected = 100;
            Assert.AreEqual(expected, knight.Health);
            expected = 0;
            Assert.AreEqual(expected, knight.VP);
        }
    }
}