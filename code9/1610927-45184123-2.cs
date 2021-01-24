    public interface IID
    {
        int Id {get; set;}
    }
    public class Teacher : IID
    {
         public int Id {get; set;}
         ...
    }
    public class Student : IID
    {
         public int Id {get; set;}
         ...
    } 
