    public class user
    {
        // navigation properties
        public DateTime lastRefresh { get; set; }
        public userParent parent { get; set; }
        // query data
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public int plan { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as user;
            return Equals(other);
        }
        protected bool Equals(user other)
        {
            if (other == null) return false;
            return string.Equals(id, other.id) && 
                created_at.Equals(other.created_at) && 
                plan == other.plan;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ created_at.GetHashCode();
                hashCode = (hashCode * 397) ^ plan;
                return hashCode;
            }
        }
    }
