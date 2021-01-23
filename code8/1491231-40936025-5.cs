    public class NumberSetList {
        public int NumberSetListId { get; set; }
        public List<NumberSetItem> Numbers { get; set; }
        public string SortOrder { get; set; }
    }
    public class NumberSetItem {
        public int Value { get; set; }
    }
