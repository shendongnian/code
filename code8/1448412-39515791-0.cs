    public abstract class BaseClass
    {
        //...
        protected Dictionary<string, object> Settings { get; set; }
        public BaseClass()
        {
            Settings = new Dictionary<string, object>()
            {
                { "Text", "SomeText" }
            };
        }
        //...
    }
