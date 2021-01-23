    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication26
    {
        class Program
        {
            static void Main(string[] args)
            {
                var menu = new Menu
                {
                    MenuID = 0,
                    IsActive = false,
                    Children =
                        new List<Menu>
                        {
                            new Menu
                            {
                                MenuID = 2,
                                IsActive = true,
                                Children =
                                    new List<Menu>
                                    {
                                        new Menu {MenuID = 4, IsActive = true},
                                        new Menu {MenuID = 5, IsActive = false}
                                    }
                            },
                            new Menu
                            {
                                MenuID = 3,
                                IsActive = true,
                                Children =
                                    new List<Menu>
                                    {
                                        new Menu
                                        {
                                            MenuID = 12,
                                            IsActive = false,
                                            Children =
                                                new List<Menu>
                                                {
                                                    new Menu {MenuID = 7, IsActive = true},
                                                    new Menu {MenuID = 8, IsActive = false}
                                                }
                                        },
                                        new Menu {MenuID = 11, IsActive = true}
                                    }
                            }
                        }
                    
                };
                var activeMenus = GetActiveMenus(menu);
                foreach (var activeMenu in activeMenus)
                {
                    Console.WriteLine(activeMenu.MenuID);
                }
                Console.ReadLine();
            }
            static IEnumerable<Menu> GetActiveMenus(Menu menu)
            {
                if (menu.IsActive)
                {
                    yield return menu;
                }
                if (menu.Children == null)
                {
                    yield break;
                }
                foreach (var child in menu.Children)
                {
                    foreach (var item in GetActiveMenus(child))
                    {
                        yield return item;
                    }
                }
            }
        }
        class Menu
        {
            public string MenuName { get; set; }
            public bool IsActive { get; set; }
            public int MenuID { get; set; }
            public IEnumerable<Menu> Children { get; set; }
        }
    }
