    class YourModelClass
    {
        public int? Year2 { get; set; }
        public int? Year3 { get; set; }
        public int? Year4 { get; set; }
        public List<int?> Years => new List<int?> {Year2, Year3, Year4};
    }
        YourModelClass model = new YourModelClass();
        string result = $"What  Company during the {string.Join(",", model.Years.Where(a => a != null).ToList())} tax years?";
