using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_System_Project
{
    internal class Program
    {
        static int maxHealth = 100;
        static int currentHealth;
        static int maxShield = 100;
        static int currentShield;
        static int maxLives = 3;
        static int currentLives;
        static int currentXP;
        static int currentLevel = 1;
        static int XPNedded = 100;
        static string healthStatus;
        static void Main(string[] args)
        {
            currentHealth = maxHealth;
            currentShield = maxShield;
            currentLives = maxLives;

            UnitTest();

            ResetGame();
        }
        static void UnitTest()
        {
            // takedamage for half shield            
            currentHealth = 100;
            currentShield = 100;
            currentLives = 3;
            TakeDamage(50);
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 50);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // Take damage from sheild to health          
            currentHealth = 100;
            currentShield = 20;
            currentLives = 3;           
            TakeDamage(50);
            Debug.Assert(currentHealth == 70);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // take damage to health
            currentHealth = 100;
            currentShield = 0;
            currentLives = 3;
            TakeDamage(80);
            Debug.Assert(currentHealth == 20);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // health dosn't go under 0
            currentHealth = 0;
            currentShield = 0;
            currentLives = 3;
            TakeDamage(50);
            Debug.Assert(currentHealth == 0);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // heal health normal
            currentHealth = 5;
            currentShield = 0;
            currentLives = 3;
            Heal(50);
            Debug.Assert(currentHealth == 55);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // heal health Max
            currentHealth = 100;
            currentShield = 0;
            currentLives = 3;
            Heal(50);
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // heal health Min
            currentHealth = 0;
            currentShield = 0;
            currentLives = 3;
            Heal(50);
            Debug.Assert(currentHealth == 0);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // heal shield normal
            currentHealth = 5;
            currentShield = 15;
            currentLives = 3;
            RegenerateShield(70);
            Debug.Assert(currentHealth == 5);
            Debug.Assert(currentShield == 85);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // heal shield max
            currentHealth = 5;
            currentShield = 100;
            currentLives = 3;
            RegenerateShield(80);
            Debug.Assert(currentHealth == 5);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // shield, health ,lives
            currentHealth = 0;
            currentShield = 0;
            currentLives = 1;
            Revive();
            TakeDamage(150);
            RegenerateShield(80);
            Heal(70);
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 80);
            Debug.Assert(currentLives == 0);
            ShowHUD();

            // heal shield min
            currentHealth = 5;
            currentShield = 0;
            currentLives = 3;
            RegenerateShield(40);
            Debug.Assert(currentHealth == 5);
            Debug.Assert(currentShield == 40);
            Debug.Assert(currentLives == 3);
            ShowHUD();

            // revive stats with lives
            currentHealth = 0;
            currentShield = 0;
            currentLives = 3;
            Revive();
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 2);
            ShowHUD();

            // revive stats without lives
            currentHealth = 0;
            currentShield = 0;
            currentLives = 0;
            Revive();
            Debug.Assert(currentHealth == 0);
            Debug.Assert(currentShield == 0);
            Debug.Assert(currentLives == 0);
            ShowHUD();

            // add revives
            currentHealth = 100;
            currentShield = 100;
            currentLives = 0;
            AddLives(1);
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 1);
            ShowHUD();

            // raise xp to level 2
            currentHealth = 100;
            currentShield = 100;
            currentLives = 3;
            currentLevel = 1;
            currentXP = 0;
            IncreaseXP(100);
            LevelUp();
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 3);
            Debug.Assert(currentLevel == 2);
            Debug.Assert(currentXP == 0);
            ShowHUD();

            // raise to level 3
            currentHealth = 100;
            currentShield = 100;
            currentLives = 3;
            currentLevel = 2;
            currentXP = 0;
            XPNedded = 200;
            IncreaseXP(220);
            LevelUp();
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 3);
            Debug.Assert(currentLevel == 3);
            Debug.Assert(currentXP == 20);
            ShowHUD();

            // raise to level 4
            currentHealth = 100;
            currentShield = 100;
            currentLives = 3;
            currentLevel = 3;
            currentXP = 0;
            XPNedded = 300;
            IncreaseXP(360);
            LevelUp();
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 3);
            Debug.Assert(currentLevel == 4);
            Debug.Assert(currentXP == 60);
            ShowHUD();

            // raise to level 5
            currentHealth = 100;
            currentShield = 100;
            currentLives = 3;
            currentLevel = 4;
            currentXP = 0;
            XPNedded = 400;
            IncreaseXP(500);
            LevelUp();
            Debug.Assert(currentHealth == 100);
            Debug.Assert(currentShield == 100);
            Debug.Assert(currentLives == 3);
            Debug.Assert(currentLevel == 5);
            Debug.Assert(currentXP == 100);
            ShowHUD();
        }
        static void ResetGame()
        {
            currentHealth = maxHealth;
            currentShield = maxShield;
            currentLives = maxLives;
            currentXP = 0;
            currentLevel = 1;
            XPNedded = 100;
        }
        static void TakeDamage(int damage)
        {
            int Spilldamage = damage - currentShield;
            
            if (currentShield > 0)
            {
                currentShield -= damage;

                if (currentShield <= 0)
                {
                    currentShield = 0;

                    if (Spilldamage > 0)
                    {
                        currentHealth -= Spilldamage;
                    }
                }
            }

            else if (currentShield <= 0)
            {
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                }
            }
        }
        static void Heal(int heal)
        {
            if (currentHealth >= 1)
            {
                currentHealth += heal;

                if (currentHealth >= 100)
                {
                    currentHealth = 100;
                }
            }
            else if (currentHealth <= 0)
            {

            }
        }
        static void RegenerateShield(int shield)
        {
            if (currentShield >= 0)
            {
                currentShield += shield;

                if (currentShield >= 100)
                {
                    currentShield = 100;    
                }
            }
            else if (currentShield >= 100)
            {

            }
        }
        static void Revive()
        {
            if (currentLives >= 1 && currentHealth <= 0)
            {
                currentLives--;
                currentHealth = 100;
                currentShield = 100;
            }
            else if (currentLives <= 0 || currentHealth <= 0)
            {
                currentLives = 0;
            }
        }
        static void AddLives(int lives)
        {
            currentLives += lives;
        }
        static void IncreaseXP(int XP)
        {
            currentXP += XP;
        }
        static void LevelUp()
        {
            if (currentXP >= XPNedded)
            {
                currentXP = currentXP - XPNedded;
                XPNedded++;
                currentLevel++;
            }
        }
        static void ShowHUD()
        {
            if (currentHealth == 100)
            {
                healthStatus = "Perfect Health!";
            }
            else if (currentLevel >= 75)
            {
                healthStatus = "Healthy";
            }
            else if (currentHealth >= 50)
            {
                healthStatus = "Injured";
            }
            else if (currentHealth >= 35)
            {
                healthStatus = "Hurt";
            }
            else if (currentHealth >= 10)
            {
                healthStatus = "Badly Hurt!";
            }
            else if (currentHealth > 0)
            {
                healthStatus = "Imminent Danger!";
            }
            else
            {
                healthStatus = "Dead!";
            }
                Console.WriteLine("===================");
            Console.WriteLine("Health | " + healthStatus);
            Console.WriteLine("Sheild | " + currentShield);
            Console.WriteLine("Lives | " + currentLives);
            Console.WriteLine("Xp | " + currentXP);
            Console.WriteLine("===================");
        }
    }
}
