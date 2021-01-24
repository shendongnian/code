    public class ComplaintTypeViewModel
    {
        public int Id { get; set; }
    }
    public class ComplaintOverviewViewModel : ComplaintTypeViewModel
    {
        public string Name { get; set; }
    }
    public class ComplaintViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
