    class Window
    {
        public void startLibrary(int sizeX, int sizeY)
        {
            BookList MainLibrary = new BookList();
            this.mainMenu(MainLibrary);
        }
        public Action<BookList> mainMenu(BookList b)
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    b.addBook();
                    break;
            }
