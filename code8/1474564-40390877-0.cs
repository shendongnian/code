    [Serializable]
    public class CTestClass : ISerializable
    {
        public CTestClass()
        {
            x = 1;
            timer = null;
        }
        public int x { get; set; }
        private System.Timers.Timer timer { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", x);
        }
    }
