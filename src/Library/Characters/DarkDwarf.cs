using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkDwarf : Enemy
    {
        public DarkDwarf(string name) : base(name)
        {
            this.AddItem(new Axe());
            this.AddItem(new Axe());
            this.VP = 2;
        }
    }
}