    public static class BookManager {
        private const string Key = "Books";
        public static Func<IHttpContextAccessor> ContextAccessor = () => new HttpContextAccessor();
    
        public static void AddBooksToContainer(IEnumerable<BookViewModel> books) {
            ContextAccessor().HttpContext.Session.Set(Key, books);
        }
    
        public static IEnumerable<BookViewModel> GetBooks() {
            return ContextAccessor().HttpContext.Session.Get<IEnumerable<BookViewModel>>(Key);
        }
    }
