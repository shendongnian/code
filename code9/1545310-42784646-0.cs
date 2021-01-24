    class objModel
    {
        // Id Module   
        public int id { set; get; }
        // Fix comm state
        public bool commState { set; get; }
        // Fix home sensor state
        public bool homeSensor { set; get; }
        // Fix up sensor state
        public bool upSensor { set; get; }
        // Fix down sensor state
        public bool downSensor { set; get; }
        // Fix actual tier position
        public int actualTier { set; get; }
        // Fix actual step of encoder
        public UInt64 encodPosition { set; get; }
    }
