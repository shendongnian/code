    public interface IBook {
    bool Initilize();
    }
    public interface IGoodBook : IBook
    {
    string Pages {get; set;}
    }
    public class Books : IGoodBook{
    
    public string Pages {get; set;}
    
    public bool Initilize(){
        Console.WriteLine("This is Initilize")
    // you need to return bool in your first message still
    }
    
    public bool Initilize(string test)
    {
      Console.WriteLine("paramter passed" + test);
      return true;
    }
    }
