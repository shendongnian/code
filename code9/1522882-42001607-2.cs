    public class Company : IEnumerable<string>{
      ...
      public IEnumerator<string> GetEnumerator() {
        return workers.GetEnumerator();
      }
      IEnumerator IEnumerable.GetEnumerator() {
        return workers.GetEnumerator();
      }
    }
