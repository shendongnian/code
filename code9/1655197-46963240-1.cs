        [DataContract]
        public class MapItem
        {
            public MapItem(bool isVisible)
            {
                this.isVisible = isVisible;
            }
            // Do not mark with [DataContract] as deserialized instances should always have the value
            // set in the OnDeserializing() callback.
            private readonly bool isVisible;
            public bool IsVisible { get { return isVisible; } }
            [OnDeserializing]
            void OnDeserializing(StreamingContext context)
            {
                typeof(MapItem)
                    .GetField(nameof(isVisible), BindingFlags.Instance | BindingFlags.NonPublic)
                    .SetValue(this, true);
            }
        }
