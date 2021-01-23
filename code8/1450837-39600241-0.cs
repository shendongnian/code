    class Window
    {
        public void startLibrary(int sizeX, int sizeY)
        {
            BookList MainLibrary = new BookList();
            Action<BookList> action = this.mainMenu();
            if (action != null)
            {
                action();
            }
        }
        public Action<BookList> mainMenu()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    return b => b.addBook();
            }
