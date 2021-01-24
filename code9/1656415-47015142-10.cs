    public static class BookManager {
        private const string Key = "Books";
        public static Func<ISession> Session = () => new HttpContextAccessor().HttpContext.Session;
    
        public static void AddBooksToContainer(IEnumerable<BookViewModel> books) {
            Session().Set(Key, books);
        }
    
        public static IEnumerable<BookViewModel> GetBooks() {
            return Session().Get<IEnumerable<BookViewModel>>(Key);
        }
    }
