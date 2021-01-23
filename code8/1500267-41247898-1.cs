    private static void ReviewFile(string fileName, string outFile)
       // You're trying to call an instance method from a static method, which doesn't make sense.
       // Also, where do you actually declare line, sw, or sr? These are, in fact,
       // declared somewhere in this method, right?
       checkFile(out line, ref sw, ref sr);  <--- error
    }
    // This is an instance method, NOT a static one
    private void checkFile(out string line, ref StreamWriter sw, ref StreamReader sr)
       {
          // "out" means you intend to initialize "line" in this method before you use it, and you don't. 
         string mVar = line.Trim();  <--- error
         sw.WriteLine(mVar);
         // ReadLine doesn't take any arguments
         // This should actually be line = sr.ReadLine()
         // Also, this should probably go at the beginning of the method
         sr.ReadLine(line);
       }
