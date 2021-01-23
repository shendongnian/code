    public class ConnectionStringWrapper
    {
        public string DefaultConnectionStringName { get; set; } = "";
        public List<ConnectionStringEntry> ConnectionStringEntries { get; set; } = new List<ConnectionStringEntry>();
        //public Dictionary<string, ConnectionStringEntry> ConnectionStringEntries { get; set; } = new Dictionary<string, ConnectionStringEntry>();
        public ConnectionStringEntry GetDefaultConnectionStringEntry()
        {
            ConnectionStringEntry returnItem = this.GetConnectionStringEntry(this.DefaultConnectionStringName);
            return returnItem;
        }
        public ConnectionStringEntry GetConnectionStringEntry(string name)
        {
            ConnectionStringEntry returnItem = null;
            if (null != this.ConnectionStringEntries && this.ConnectionStringEntries.Any())
            {
                returnItem = this.ConnectionStringEntries.FirstOrDefault(ce => ce.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            if (null == returnItem)
            {
                throw new ArgumentOutOfRangeException(string.Format("No default ConnectionStringEntry found. (ConnectionStringEntries.Names='{0}', Search.Name='{1}')", this.ConnectionStringEntries == null ? string.Empty : string.Join(",", this.ConnectionStringEntries.Select(ce => ce.Name)), name));
            }
            return returnItem;
        }
    }
