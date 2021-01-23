    public class Summary
    {
        public string Name { get; set; }
        public int Marks { get; set; }
    }
    SummaryList.Add(new ActivitySummary() {
        Name =  "TOTAL",
        Marks = SummaryList.Sum(item => item.Marks)
    });
