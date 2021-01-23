    [DataContract]
    class C1 
    {
        private object mySyncObject = new object();
        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            mySyncObject = new object();
        }
    }
