    public class YourCollectionClass
        {
            [SitecoreChildren(InferType = true)]
            public virtual IEnumerable<CallItemBase> CallItems{ get; set; }
        }
