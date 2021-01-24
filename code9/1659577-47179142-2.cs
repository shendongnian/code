    public class DayRateComparer : IEqualityComparer<CareRate>
    {
        public bool Equals(CareRate x, CareRate y) {
            if (x = null) throw new ArgumentNullException(nameof(x));
            if (y = null) throw new ArgumentNullException(nameof(y));
            
            return x.Id == y.Id && x.DayRate == y.DayRate;
        }
    
        public int GetHashCode(CareRate obj) {
            retun obj.Id.GetHashCode() + obj.DayRate.GetHashCode(); 
        }
    }
