    public class Criteria
    {
        public Criteria() // perhaps add some defaults?
        {
            PageNo = 1;
            PageSize = 5;
        }
        public int? SnapshotKey { get; set; }
        public string Delq { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        .... // see method below
    }
