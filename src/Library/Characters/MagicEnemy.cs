using System.Collections.Generic;

namespace RoleplayGame
{
    public class MagicEnemy : Enemy
    {

        protected List<IMagicalItem> magicalItems = new List<IMagicalItem>();

        public MagicEnemy(string name) : base(name)
        {

        }
        public void AddItem(IMagicalItem item)
        {
            this.magicalItems.Add(item);
        }

        public void RemoveItem(IMagicalItem item)
        {
            this.magicalItems.Remove(item);
        }

        public new int AttackValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    value += item.AttackValue;
                }
                foreach (Item item in this.magicalItems)
                {
                    value += item.AttackValue;
                }
                return value;
            }
        }

        public new int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (Item item in this.items)
                {
                    value += item.DefenseValue;
                }
                foreach (Item item in this.magicalItems)
                {
                    value += item.DefenseValue;
                }
                return value;
            }
        }
    }
}
