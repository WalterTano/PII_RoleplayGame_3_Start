namespace RoleplayGame
{
    public class Hero : Character
    {
        public Hero(string name) : base(name)
        {
            this.VP = 0;
        }

        public void AddVP(int vp)
        {
            this.VP += vp;
            if (this.VP >= 5)
            {
                this.Cure();
                this.VP = 0;
            }
        }

        public int VP { get; protected set; }
    }
}