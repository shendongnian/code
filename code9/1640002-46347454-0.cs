    public class ReadingTextFile: IReadingTextFile {
      public IEnumerable<string> content() {                  // change the return type
       string path = @ "C:\Users\s\Desktop\Datas\Data Input.txt";
       var data = File.ReadAllLines(path);                    // and this
       return data;
      }
     }
    
