    public class AgeGroupVM
    {
        public string Name { get; set; }
        public IEnumerable<AppVM> Apps { get; set; }
    }
    public class AppVM
    {
        public string Name { get; set; }
        public string StoreURL { get; set; }
        public string AppIcon { get; set; }
    }
