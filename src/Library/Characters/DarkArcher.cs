using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkArcher : Enemy
    {
        public DarkArcher(string name) : base(name)
        {
            this.AddItem(new Bow());
            this.AddItem(new Bow());
            this.AddItem(new Bow());
            this.VP = 1;
        }
    }
}