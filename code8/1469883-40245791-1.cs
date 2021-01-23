    class Program
    {
        //represents a line/option in a menu
        class MenuItem
        {
            // displayed in the menu
            public string Text { get; set; }
            //is there a sub menu
            public bool HasSubMenu { get; set; }
            // if there's a submenu, what's its id
            public int? SubMenuId { get; set; }
            //if there isn't a sub menu, what should we do
            public Action Action { get; set; }
        }
        //represents one menu i.e. a collection of options
        class Menu
        {
            public Menu()
            {
                MenuItems = new List<MenuItem>();
            }
            public int MenuId { get; set; }
            public List<MenuItem> MenuItems { get; set; }
            public string Title { get; set; }
            public void PrintToConsole()
            {
                foreach (MenuItem item in MenuItems)
                {
                    Console.WriteLine(MenuItems.IndexOf(item) + " : " + item.Text);
                }
            }
        }
        //represents all the menus
        class MenuCollection
        {
            public MenuCollection()
            {
                Menus = new List<Menu>();
            }
            public List<Menu> Menus { get; set; }
            public void ShowMenu(int id)
            {
                //get the menu we want to display and call its PrintToConsole method
                var currentMenu = Menus.Where(m => m.MenuId == id).Single();
                currentMenu.PrintToConsole();
                //wait for user input
                string choice = Console.ReadLine();
                int choiceIndex;
                //once we have the users selection make sure its an integer and in range of our menu options
                //if not then show an error message and re-display the menu
                if (!int.TryParse(choice, out choiceIndex) || currentMenu.MenuItems.Count < choiceIndex || choiceIndex < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection - try again");
                    ShowMenu(id);
                }
                else
                {
                    // if the selection is good, then retrieve the corresponding menu item
                    var menuItemSelected = currentMenu.MenuItems[choiceIndex];
                    // if there's a sub menu then display it
                    if (menuItemSelected.HasSubMenu)
                    {
                        Console.Clear();
                        ShowMenu(menuItemSelected.SubMenuId.Value);
                    }
                    // otherwise perform whatever action we need
                    else
                    {
                        menuItemSelected.Action();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // build a collection of menus
            // can have as deep a structure as you like
            // give each menu a unique integer MenuId
            // link to other menus by setting HasSubMenu to true, and the SubMenuId to the MenuId of the menu you wish to link to
            // or, set HasSubMenu to false, and have an Action performed when the menuitem is selected
            MenuCollection collection = new MenuCollection()
            {
                Menus =
                {
                    new Menu()
                    {
                        MenuId = 1,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Go to sub menu",
                                HasSubMenu = true,
                                SubMenuId = 2
                            },
                            new MenuItem()
                            {
                                Text = "Print Action",
                                HasSubMenu = false,
                                Action = () => 
                                {
                                     Console.WriteLine("I printed from an action");
                                }
                            }
                        }
                    },
                    new Menu()
                    {
                        MenuId = 2,
                        MenuItems =
                        {
                            new MenuItem()
                            {
                                Text = "Sub menu option 1",
                                HasSubMenu = false,
                                Action = () => 
                                {
                                    Console.WriteLine("Printed from a sub menu");
                                }
                            },
                            new MenuItem()
                            {
                                Text = "Back to the top menu",
                                HasSubMenu = true,
                                SubMenuId = 1
                            }
                        }
                    }
                }
            };
            collection.ShowMenu(1);
            Console.ReadLine();
        }
    }
