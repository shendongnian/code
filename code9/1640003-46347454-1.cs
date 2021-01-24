     public class Readingtolist {
      public void Input() {
       IReadingTextFile file = new ReadingTextFile();
       Stopwatch sw = new Stopwatch();
       sw.Start();
       IEnumerable<string> inp = file.content();    // the reading the file is bet is what you really want to time.
       sw.Stop();
       var data = new LinkedList<string>(inp);    // note the use of (inp) here
       Console.Write("\n time Taken For Read Data: {0} ms",
        sw.Elapsed.TotalMilliseconds);
       Console.WriteLine("\n The items are{0}", inp);
      }
     }
