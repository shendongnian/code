    public class ComplaintTypeViewModel
    {
        public int Id { get; set; }
    }
    public class ComplaintOverviewViewModel : ComplaintTypeViewModel
    {
        public string Name { get; set; }
    }
    public class ComplaintViewModel : ComplaintOverviewViewModel
    {
        public string Details { get; set; }
    }
