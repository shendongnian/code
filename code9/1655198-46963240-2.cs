        [Serializable]
        public class MapItem : ISerializable
        {
            public MapItem(bool isVisible)
            {
                this.isVisible = isVisible;
            }
            private readonly bool isVisible;
            public bool IsVisible { get { return isVisible; } }
            #region ISerializable Members
            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
            #endregion
            protected MapItem(SerializationInfo info, StreamingContext context)
            {
                this.isVisible = true;
            }
        }
    However this is **not recommended** as you now would need to serialize all of your class's members manually.
