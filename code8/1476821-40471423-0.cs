    class Given
    {
        public Given(){
            this.text = "";
            start_conditions = new List<StartCondition>();
        }
        public string text { get; set; }
        public List<StartCondition> start_conditions { get; set; }
    };
    
    class StartCondition
    {
        public StartCondition(){
            this.index = 0;
            this.device = "unknown";
            this.state = "disconnected";
            this.isPass = false;
        }
        public int index { get; set; }
        public string device { get; set; }
        public string state { get; set; }
        public bool isPass { get; set; }
    };
