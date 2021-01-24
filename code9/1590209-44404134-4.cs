     public class BookGroup
     {
        public string ImagePath {get;set;}
        public List<string> Books {get;}
        public BookGroup(string imagePath, params string[] books)
        {
            ImagePath = imagePath;
            Books = new List<string>(books.Length);
            Books.AddRange(books);
        }
     }
