    public class BootgridResponseData<T> where T : class
    {
        public int current { get; set; } //? current page
        public int rowCount { get; set; } //? rows per page
        public IEnumerable<T> rows { get; set; } //? items
        public int total { get; set; } //? total rows for whole query
    }
    
