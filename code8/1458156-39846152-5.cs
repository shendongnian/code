    class Action_t
    {
        public Action_t()
        {
            repeat_interval = 0;
        }
        public UInt32 repeat_interval { get; set; }
        private UInt32 _repeat_duration = 0;
        public UInt32 repeat_duration
        {
            get { return _repeat_duration; }
            set { _repeat_duration = value; }
        }
        public bool isDone { get; set; } = false; // valid for C# 6
    }
