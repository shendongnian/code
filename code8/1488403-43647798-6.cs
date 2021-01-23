    public class ConnectionStringSettings
    {
        public String Name { get; set; }
        public String ConnectionString { get; set; }
        public String ProviderName { get; set; }
        public ConnectionStringSettings()
        {
        }
        public ConnectionStringSettings(String name, String connectionString)
            : this(name, connectionString, null)
        {
        }
        public ConnectionStringSettings(String name, String connectionString, String providerName)
        {
            this.Name = name;
            this.ConnectionString = connectionString;
            this.ProviderName = providerName;
        }
        protected bool Equals(ConnectionStringSettings other)
        {
            return String.Equals(Name, other.Name) && String.Equals(ConnectionString, other.ConnectionString) && String.Equals(ProviderName, other.ProviderName);
        }
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConnectionStringSettings) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConnectionString != null ? ConnectionString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProviderName != null ? ProviderName.GetHashCode() : 0);
                return hashCode;
            }
        }
        public static bool operator ==(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ConnectionStringSettings left, ConnectionStringSettings right)
        {
            return !Equals(left, right);
        }
    }
