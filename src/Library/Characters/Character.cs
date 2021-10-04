using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Character
    {
        protected int health = 100;
        protected List<Item> items = new List<Item>();

        public Character(string name)
        {
            this.Name = name;
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
        }

        public void Cure()
        {
            this.health = 100;
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public string Name { get; set; }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    value += item.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    value += item.DefenseValue;
                }
                return value;
            }
        }
    }
}