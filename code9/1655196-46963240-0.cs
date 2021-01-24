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
    For convenience of existing devs you could even introduce a private property with the same name as the old field:
            private bool isVisible { get { return !isNotVisible; } }
    I can't say I really recommend this however.
