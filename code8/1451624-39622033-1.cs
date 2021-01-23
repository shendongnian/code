     internal class MaintenanceWindow
     {
        public object @from { get; set; }
        public object to { get; set; }
        public object abbreviation { get; set; }
        private readonly string _description;
        public string Description => _description;
        public MaintenanceWindow(string description)
        {
            _description = description;
        }
        public string hosts { get; set; }
        public override bool Equals(object obj)
        {
            return this.Equals((MaintenanceWindow)obj);
        }
        protected bool Equals(MaintenanceWindow other)
        {
            return string.Equals(_description, other._description);
        }
        public override int GetHashCode()
        {
            return _description?.GetHashCode() ?? 0;
        }
    }
 
