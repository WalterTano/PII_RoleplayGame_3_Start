using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkKnight : Enemy
    {
        public DarkKnight(string name) : base(name)
        {
            this.AddItem(new Sword());
            this.AddItem(new Sword());
            this.VP = 2;
        }
    }
}