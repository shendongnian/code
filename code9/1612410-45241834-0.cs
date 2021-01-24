    class MenuSystem
    {
        public static void Control(List<string> menuItems)
        {
            var selectedIndex = 0;
            var exitMenu = false;
           
            while (!exitMenu)
            {
                DisplayMenu(selectedIndex, menuItems);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        selectedIndex -= 1;
                        if (selectedIndex < 0) selectedIndex = menuItems.Count - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        selectedIndex += 1;
                        if (selectedIndex > menuItems.Count - 1) selectedIndex = 0;
                        break;
                    case ConsoleKey.Enter:
                        exitMenu = true;
                        break;
                }
            }
        }
        private static void DisplayMenu(int selectedIndex, List<string> menuItems)
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.Write("[" + menuItems[i] + "]");
                }
                else
                {
                    Console.Write(" " + menuItems[i] + " ");
                }
                Console.Write("  ");
            }
        }
    }
