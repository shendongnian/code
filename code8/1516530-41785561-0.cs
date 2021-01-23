       public string Title {get; set;}
       public abstract string Read(int pageNum);
    }
    
    public class ITBook : Book
    {
       public override string Read(int pageNum)
       {
          // Code here
       }
    }
