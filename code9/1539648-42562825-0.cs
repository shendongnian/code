    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    namespace Game
    {
        class Program
        {
            static void Main (string[] args)
            {
                IAppModule module = new MainMenuModule ();
                while (true)
                {
                    module = module.Run ();
                    Console.Clear ();
                }
            }
        }
        public class Character
        {
            public string Name;
            public int Health, Armor, Damage;
            public static Character Warrior => new Character { Name = "Warrior", Health = 600, Armor = 20, Damage = 80  };
            public static Character Archer  => new Character { Name = "Archer",  Health = 250, Armor =  5, Damage = 35  };
            public static Character Mage    => new Character { Name = "Mage",    Health =  90, Armor =  0, Damage = 150 };
        }
        public interface IAppModule
        {
            IAppModule Run ();
        }
        public class ExitGameModule : IAppModule
        {
            public IAppModule Run ()
            {
                Console.WriteLine ("Thanks for playing!");
                Thread.Sleep (2000);
                Environment.Exit (0);
                return null;
            }
        }
        public class MainMenuModule : IAppModule
        {
            public IAppModule Run ()
            {
                var menu = new Menu ("Main menu:");
                menu.AddMenuEntry ("1", "start adventure", new SelectHeroModule ());
                menu.AddMenuEntry ("q", "exit game", new ExitGameModule ());
                return menu.Execute ();
            }
        }
        public class SelectHeroModule : IAppModule
        {
            public IAppModule Run ()
            {
                var mm = new Menu ("Select Hero");
                mm.AddMenuEntry ("1", "Paladin", new PlayModule (Character.Warrior));
                mm.AddMenuEntry ("2", "Archer",  new PlayModule (Character.Archer ));
                mm.AddMenuEntry ("3", "Mage",    new PlayModule (Character.Mage   ));
                mm.AddMenuEntry ("q", "Back to main menu", new MainMenuModule ());
                return mm.Execute ();
            }
        }
        public class PlayModule  : IAppModule
        {
            private Character character;
            public PlayModule  (Character character)
            {
                this.character = character;
            }
            public IAppModule Run ()
            {
                Console.WriteLine ("You are playing: " + character.Name);
                Console.WriteLine ("Health: " + character.Health);
                Console.WriteLine ("Armor: " + character.Armor);
                Console.WriteLine ("Damge: " + character.Damage);
                // game logic here
                Console.WriteLine ("\r\nPress any key to exit to menu.");
                Console.ReadKey ();
                return new MainMenuModule ();
            }
        }
        // helper class for building text menus
        public class Menu
        {
            private string title;
            private List<MenuItem> items = new List<MenuItem> ();
            public Menu (string title)
            {
                this.title = title;
            }
            public void AddMenuEntry (string cmd, string description, IAppModule module)
            {
                var item = new MenuItem
                {
                    Command     = cmd,
                    Description = description,
                    Module      = module
                };
                items.Add (item);
            }
            public IAppModule Execute ()
            {
                Console.WriteLine ($"***** {title} *****\r\n");
                foreach (var item in items)
                {
                    Console.WriteLine ($"{item.Command} - {item.Description}");
                }
                var cmd = GetCommand ();
                return items.First (x => x.Command == cmd).Module;
            }
            private string GetCommand ()
            {
                while (true)
                {
                    Console.Write ("\r\nYour choice: ");
                    string cmd = Console.ReadLine ();
                    if (items.Any (x => x.Command == cmd)) return cmd;
                    Console.WriteLine ("Invalid choice. Try again.");
                }
            }
        }
        public class MenuItem
        {
            public string Command, Description;
            public IAppModule Module;
        }
    }
