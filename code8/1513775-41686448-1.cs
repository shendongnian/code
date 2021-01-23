    public class A : IEnumerable {
       private List<string> items = new List<string>();
       public IEnumerator GetEnumerator() {
          return this.items.GetEnumerator();
       }
    }
