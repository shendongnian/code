    class Period {
        public DateTime Start { get; }
        public DateTime End { get; }
        public Period(DateTime start, DateTime end) {
            this.Start = start;
            this.End = end;
        }
        public int Overlap(Period other) {
            DateTime a = this.Start > other.Start ? this.Start : other.Start;
            DateTime b = this.End < other.End ? this.End : other.End;
            return (a < b) ? b.Subtract(a).Days : 0;
        }
    }
    class IdData {
        public IdData() {
            this.Periods = new List<Period>();
            this.Overlaps = new Dictionary<int, int>();
        }
        public List<Period> Periods { get; }
        public Dictionary<int, int> Overlaps { get; }
    }
