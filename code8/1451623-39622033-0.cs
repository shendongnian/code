    internal class MaintenanceWindow
    {
        public object @from { get; set; }
        public object to { get; set; }
        public object abbreviation { get; set; }
        public string description { get; set; }
        public string hosts { get; set; }
    public override bool Equals(object obj)
    {
        return this.Equals((MaintenanceWindow)obj);
    }
    protected bool Equals(MaintenanceWindow other)
    {
        return string.Equals(description, other.description);
    }
    public override int GetHashCode()
    {
        return description?.GetHashCode() ?? 0;
    }
    }
