using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkWizard : MagicEnemy
    {

        public DarkWizard(string name) : base(name)
        {
            this.Name = name;

            this.AddItem(new Staff());
            this.AddItem(new Staff());
            this.VP = 3;
        }

    }
}