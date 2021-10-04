using System.Collections.Generic;
namespace RoleplayGame
{
    public class Encounter
    {
        public List<Hero> Heroes { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public Encounter(List<Hero> heroes, List<Enemy> enemies)
        {
            this.Heroes = heroes;
            this.Enemies = enemies;
        }

        public void DoEncounter()
        {
            while (this.Heroes.Count > 0 && this.Enemies.Count > 0)
            {
                this.EnemysTurn();
                this.HerosTurn();
            }
        }

        private void EnemysTurn()
        {
            int heroIndex = 0;
            foreach (Enemy enemy in this.Enemies)
            {
                this.Heroes[heroIndex].ReceiveAttack(enemy.AttackValue);
                if (this.Heroes[heroIndex].Health <= 0)
                {
                    this.Heroes.RemoveAt(heroIndex);
                }
                heroIndex = (heroIndex + 1) >= this.Heroes.Count ? 0 : heroIndex + 1;
            }
        }

        private void HerosTurn()
        {
            foreach (Hero hero in this.Heroes)
            {
                for (int i = 0; i < this.Enemies.Count; i++)
                {
                    Enemy enemy = this.Enemies[i];
                    enemy.ReceiveAttack(hero.AttackValue);
                    if (enemy.Dead)
                    {
                        hero.AddVP(enemy.VP);
                        this.Enemies.RemoveAt(i);
                        i -= 1;
                    }
                }
            }
        }
    }
}