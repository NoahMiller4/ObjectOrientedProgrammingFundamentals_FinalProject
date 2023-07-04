using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals_FinalProject.Classes
{
    public class Fight
    {

        public static void FightText(Hero hero, Monster monster)
        {
            Console.WriteLine($"You delve into the depths of Everdoom! In the dark shallows" +
                $" of the cave, you see a shadow rushing towards you!");
            Console.WriteLine($"{monster.Name} tears out of the shadows at you!" +
                $" You draw your {hero.EquippedWeapon.Name} and start to battle!");
            Console.WriteLine($"Health: {monster.CurrentHealth}, Strength:" +
                $" {monster.Strength}, Defence: {monster.Defence}");
            Console.WriteLine();
        }
        // must make startfight static to call in my switch case
        public static void StartFight(Hero hero, Monster monster)
        {
            // damage values with power and defense added
            int heroTurn = hero.BaseStrength + hero.EquippedWeapon.Power - monster.Defence;
            int monsterTurn = monster.Strength - hero.BaseArmour - hero.EquippedArmor.Power;
            // set heroturn to 1 if it is negative, as cannot have negative damage done.
            if (heroTurn <=0)
            {
                heroTurn = 1;
            }

            if (hero.CurrentHealth >= 1 || monster.CurrentHealth >= 1)
            {
                monster.CurrentHealth -= heroTurn;
                Console.WriteLine($"The hero damaged the monster for {heroTurn} amount!" +
                    $"Monsters current health is: {monster.CurrentHealth}");
                Console.WriteLine();
                
            }

            if(monster.CurrentHealth >= 1)
            {
                hero.CurrentHealth -= monsterTurn;
                Console.WriteLine($"The monster damaged the hero for {monsterTurn} amount! " +
                    $"{hero.HeroName}s current health is: {hero.CurrentHealth}");
                Console.WriteLine();
            }

            // Checking result of fight (Lose)
            if (hero.CurrentHealth <= 0)
            {
                Game.FightsLost++;
                hero.CurrentHealth = hero.OriginalHealth;
                Console.WriteLine("You lost the fight. GAME OVER!");
                monster.ResetHealth();
                Game.GamesPlayed++;
                Game.MainMenu();
            }
            if (monster.CurrentHealth <= 0) // Win
            {
                Game.FightsWon++;
                hero.CurrentHealth = hero.OriginalHealth;
                Console.WriteLine("Congratulations! You won the fight!");
                Game.RemoveMonster(monster);
                monster.ResetHealth();
            }
            else
            {
                // Continue the fight with the same monster
                StartFight(hero, monster);
            }

            Game.GamesPlayed++;
            Console.WriteLine();
            Game.MainMenu();
        }
    }
}
