namespace RoleplayGame
{
    public abstract class AttackItem: Item
    {
        public new int DefenseValue {
            get {
                return 0;
            }
        }
    }
}