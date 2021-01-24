    public class CarKey : IEquatable<CarKey>
    {
        public CarKey(string carModel, string engineType, int year)
        {
            CarModel = carModel;
            EngineType= engineType;
            Year= year;
        }
        public string CarModel {get;}
        public string EngineType {get;}
        public int Year {get;}
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int) 2166136261;
        
                hash = (hash * 16777619) ^ CarModel?.GetHashCode() ?? 0;
                hash = (hash * 16777619) ^ EngineType?.GetHashCode() ?? 0;
                hash = (hash * 16777619) ^ Year.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals(other as CarKey);
        }
        public bool Equals(CarKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(CarModel,obj.CarModel) && string.Equals(EngineType, obj.EngineType) && Year == obj.Year;
        }
    }
