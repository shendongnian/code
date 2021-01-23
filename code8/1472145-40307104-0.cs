     static void Main(string[] args) {
       for (int i = 0; i < 7; i++) { // do not use magic numbers: what does, say, 5 stand for?
         // we want weekdays, not int to be printed out
         weekdays wd = (weekdays) i;
    
         Console.WriteLine(wd);
       }
    
       Console.Read();
     }
