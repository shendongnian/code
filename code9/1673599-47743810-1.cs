    public class ModelItem
    {
        double? Value { get; set; }
    }
    public class Model
    {
        public ICollection<ModelItem> Items { get; set; } // for some reason, e.g. serialization, the Items collection can be null
    
        public double? Average
        {
            if (Items == null)
            {
                // I don't know what items exist => the average is unknown
                return null;
            }
            return Items.Average(i => i?.Value); // note the ?. here to prevent NullReferenceException
        }
    }
