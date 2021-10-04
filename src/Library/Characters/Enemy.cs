namespace RoleplayGame
{
    public class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
            this.Dead = false;
        }

        public new void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
            this.Dead = Health == 0;
        }

        public int VP { get; protected set; }
        public bool Dead { get; protected set; }
    }
}