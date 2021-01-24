    [HttpPost]
    public int GetSampleItems(List<SampleItem> sampleItems)
    {
        return sampleItems.Length;
    }
    public class SampleItem
    {
        public string Item { get; set; }
    }
