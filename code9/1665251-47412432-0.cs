      public class SalesProductComparer : IEqualityComparer<Sales>
      {
        public bool Equals(Sales x, Sales y)
        {
          return x.Product1 == y.Product1 && x.Product2 == y.Product2;
        }
        public int GetHashCode(Sales obj)
        {
          return obj.Product1 + 65537 * obj.Product2;
        }
      }
