namespace RoleplayGame
{
    public abstract class AttackItem : Item
    {
        public override int DefenseValue
        {
            get
            {
                return 0;
            }
        }
    }
}