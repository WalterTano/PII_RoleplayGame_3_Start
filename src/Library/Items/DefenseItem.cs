namespace RoleplayGame
{
    public abstract class DefenseItem : Item
    {
        public new int AttackValue {
            get {
                return 0;
            }
        }
    }
}