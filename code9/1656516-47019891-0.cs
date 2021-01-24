    //Raw data
    public class DataRowModel
    {
        public int Id { get; set; }
        public string Class{ get;set;}
        public string Description { get; set; }
        public DateTime BookingDate { get; set; }
    }
    //Grouped data
    public class GroupedDataRowModel
    {
        public string Class { get; set; }
        public IEnumerable<DataRowModel> Rows { get; set; }
    }
    //View model
    public class DataRowsViewModel
    {
        public IEnumerable<GroupedDataRowModel> Results { get; set; }
    }
