    class txt_program {
      // () You don't use "args" in the method
      public void txt(){ 
        string[] names = new string[] { "max", "lars", "john", "iver", "erik" };
        
        // wrap IDisposable (StreamWriter) into using 
        using (StreamWriter SW = new StreamWriter(@"txt.txt")) {
          // do not use magic numbers - 5. 
          // You want write all items, don't you? Then write them  
          foreach (var name in names)
            SW.WriteLine(name);
        }
      }
    }
    ...
    static void Main(string[] args){
      // create an instance and call the method
      new txt_program().txt();
    }
