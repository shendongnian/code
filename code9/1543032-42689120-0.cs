    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    public class Boss
    {
        public int redKeeperHealth = 100;
    }
    public class Player
    {
        public int playerHealth = 100;
        public string playerName = "Ace";
    }
    class Program
    {
        public static Boss boss = new Boss();
        public static Player player = new Player();
        static void Main(string[] args)
        {
            redKeeperBattle();
        }
        public static void redKeeperBattle()
        {
            //Player damage
            Random pDmg = new Random();
            int playerDmg;
            //Player dodge
            Random pDodge = new Random();
            int playerDodge;
            //Player crit
            Random pCrit = new Random();
            int playerCrit;
            //Red keeper damage
            Random rDmg = new Random();
            int redDmg;
            while (boss.redKeeperHealth > 0 && player.playerHealth > 0)
            {
                PrintToScreen();
                int playerChoice = ReadPlayerChoice();
                if (playerChoice == 1)
                {
                    playerDmg = pDmg.Next(5, 16);
                    playerCrit = pCrit.Next(10, 16);
                    if (playerCrit == 15)
                    {                        
                        playerDmg += playerCrit;
                        Console.WriteLine("");
                        Console.Write("You critically struck ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("You hit The Red Keeper for {0}", playerDmg);
                    boss.redKeeperHealth -= playerDmg;
                    redDmg = rDmg.Next(1, 21);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("The Red Keeper ");
                    Console.ResetColor();
                    Console.WriteLine("hit you for {0}", redDmg);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    redDmg = rDmg.Next(1, 21);
                    player.playerHealth -= redDmg;
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    Console.ResetColor();                    
                }
                else if (playerChoice == 2)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("You attempt to dodge!");
                    Console.ResetColor();
                    Console.ReadLine();
                    playerDodge = pDodge.Next(1, 11);
                    if (playerDodge > 5)
                    {
                        redDmg = rDmg.Next(1, 21);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You successfully dodged and gained 10 HP!");
                        Console.ReadLine();
                        player.playerHealth += 10;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("The Red Keeper ");
                        Console.ResetColor();
                        Console.WriteLine("would have hit you for {0} HP!", redDmg);
                        Console.ReadLine();
                    }
                    else
                    {
                        redDmg = rDmg.Next(1, 21);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dodge failed!");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("The Red Keeper ");
                        Console.ResetColor();
                        Console.WriteLine("hit you for {0}", redDmg);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Press Enter to end his turn...");
                        Console.ResetColor();
                        player.playerHealth -= redDmg;
                        Console.ReadLine();
                    }
                    
                }                
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error occurred! Please try again!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Press Enter to continue...");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                if (boss.redKeeperHealth <= 0 && player.playerHealth <= 0)
                {
                    Console.Write("You have defeated ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Red Keeper!");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Write("But you have also ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Died!");
                    Console.ResetColor();
                    Console.ReadLine();
                    playerDeath();
                }
                if (player.playerHealth <= 0 && boss.redKeeperHealth > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("The Red Keeper ");
                    Console.ResetColor();
                    Console.WriteLine("has killed {0}, how sad...", player.playerName);
                    Console.ReadLine();
                    playerDeath();
                }
                if (boss.redKeeperHealth <= 0 && player.playerHealth > 0)
                {
                    Console.Write("You have defeated ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Red Keeper!");
                    Console.ResetColor();
                    Console.ReadLine();
                    redKeeperRoom();
                }
            }
        }
        public static void redKeeperRoom()
        {
            //Continue game
            Console.WriteLine("The boss has died!");
            Console.ReadLine();
        }
        public static void playerDeath()
        {
            //End game
            Console.WriteLine("You have Died!");
            Console.ReadLine();
        }
        private static void PrintToScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("THE RED KEEPER: {0} HP", boss.redKeeperHealth);
            Console.ResetColor();
            Console.WriteLine("");
            Console.Write("{0}: ", player.playerName);
            if (player.playerHealth > 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (player.playerHealth > 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("{0}", player.playerHealth);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Dodge");
            Console.WriteLine("");
            Console.ResetColor();
        }
        private static int ReadPlayerChoice()
        {
            return int.Parse(Console.ReadLine());
        }
    }
