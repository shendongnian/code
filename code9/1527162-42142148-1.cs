    public class ExhibitionComparer : IEqualityComparer<Exhibition>
    {
        public bool Equals(Exhibition x, Exhibition y)
        {
            return x.Location == y.Location && x.Type == y.Type && x.Price == y.Price;
        }
        public int GetHashCode(Exhibition obj)
        {
            return obj.GetHashCode();
            
        }
    }
