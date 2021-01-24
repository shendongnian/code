        [DataContract]
        public class MapItem
        {
            // Do not mark with [DataContract] as deserialized instances should always have the default value
            private readonly bool isNotVisible; 
            public MapItem(bool isVisible)
            {
                this.isNotVisible = !isVisible;
            }
            public bool IsVisible { get { return !isNotVisible; } }
        }
