    class Window
    {
        private BookList MainLibrary;
    
        public void startLibrary(int sizeX, int sizeY)
        {
            this.MainLibrary = new BookList();
            this.mainMenu();
        }
        
        public void mainMenu()
        {
            string userChoice = Console.ReadLine();
            switch  (userChoice)
            {
                case "1":
                    // do whatever you want with this.MainLibrary here
                    break;
                /// ...
            }
        }
    }
