    class Program
    {
        private static Queue<Reader> borrowers = new Queue<Reader>();
        private static Queue<Reader> returners = new Queue<Reader>();
        private static Stack<Book> books = new Stack<Book>();
