    public class Dockets<T> : IDockets
    {
        private IEnumerable<T> dockets;
        public Dockets(IEnumerable<T> dockets)
        {
          this.dockets = dockets;
        }
        public void DoSomethingWithRecords()
        {
            foreach(var docket in dockets)
                 Console.WriteLine(docket); // do whatever
        }
    } 
