    public class Book{
       Func<int, string> readFunc;
       public Book(Func<int, string> readFunc)
       {
         this.readFunc = readFunc;
       }
       public string Title {get; set;}
       public string Read(int pageNum) { return readFunc(pageNum); }
    }
    
