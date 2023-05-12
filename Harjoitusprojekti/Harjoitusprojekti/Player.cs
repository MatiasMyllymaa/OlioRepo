using System;

namespace Harjoitusprojekti
{
    class Player
    {
        
        public int Health { get; set; } = 100;

        
        public int AttackDamage { get; set; } = 10;

        
        public int AbilityCooldown { get; set; } = 3;

        
        private int abilityCooldownRemaining = 0;


        public bool IsDefeated() { return Health <= 0; }

        public int Money { get; set; } = 0;

        public int pottu { get; set; } = 0;

        
        public void Attack(Enemy enemy)
        {
            int damage = AttackDamage;
            Console.WriteLine($"Sinä hyökkäät viholliseen ja teet {damage} damagea!");

            
            enemy.TakeDamage(damage);
        }

        
        public void UseAbility(Enemy enemy)
            {
            
            if (abilityCooldownRemaining > 0)
            {
            Console.WriteLine("Abilityssäsi on vielä cooldown!");
                return;
            }

            int damage = AttackDamage * 2;
            Console.WriteLine($"sinä käytät abilitysi viholliseen ja teet {damage} damagea!");

            
            enemy.TakeDamage(damage);

            
            abilityCooldownRemaining = AbilityCooldown;
        }

            
            public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"sinä otat {damage} damagea vihulta!");
        }
    }
}