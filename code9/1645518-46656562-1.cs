    public class ComplaintTypeViewModel
    {
        public int Id { get; set; }
    }
    public class ComplaintOverviewViewModel : ComplaintTypeViewModel
    {
        public string Name { get; set; }
    }
    public class ComplaintViewModel : ComplaintTypeViewModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
    }
