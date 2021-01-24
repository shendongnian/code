    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Detail> Details { get; set; }
        public string GoodDetails
        {
            get { return String.Join(",", Details.Where(x => x.Good == true).Select(y => y.Name)); }
        }
    }
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Good { get; set; }
    }
