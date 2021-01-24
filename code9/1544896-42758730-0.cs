    public class FileList : IList
    {
       public void Add(object item)
       {
          try
          {
          }
          //Here I could need this Exception which you can't know on interface-Level
          catch(FileNotFoundException ex)
          {
          }
       }
    }
