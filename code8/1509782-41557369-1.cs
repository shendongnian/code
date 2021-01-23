    public class Interval
    {
        public int start; // consider to use properties
        public int end;
        public Interval(): this (0,0) { } // you can call second constructor here
        public Interval(int s, int e) { start = s; end = e; }
        public override void ToString()
        {
            return $"[{start},{end}]";
        }
    }
