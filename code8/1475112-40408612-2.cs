    public class YourCollectionClass
        {
            [SitecoreChildren(InferType = true)]
            public virtual IEnumerable<CallItem> CallItems{ get; set; }
        }
