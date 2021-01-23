    public class r_event
    {
        public string name { get; set; }
        public double time { get; set; }
        public r_event()
        {
            name = "none";
            time = 0;
        }
        public r_event(string name, double time)
        {
            this.name = name;
            this.time = time;
        }
    }
