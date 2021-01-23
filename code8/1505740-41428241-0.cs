    public class AnonymousType1
    {
        public int Department { get; set; } // I don't know your department type
        public int Gender { get; set; } // neither your gender type
        public int GetHashCode() { return Department.GetHashCode() ^ Gender.GetHashCode(); }
        public bool Equals(AnonymousType1 other)
        {
            if (ReferenceEquals(other, null)) return false;
            return Department == other.Department && Gender == other.Gender;
        }
    }
