    public class Header
    {
        static int _headerIdSeed = 0;
        public int HeaderId { get; internal set; } = _headerIdSeed++;
        public IList<Line> Lines { get; } = new List<Line>();
        public Header Add(Line line)
        {
            line.HeaderId = this.HeaderId;
            this.Lines.Add(line);
            return this;
        }
        public Header Add(params Line[] lines)
        {
            return this.AddRange(lines);
        }
        public Header AddRange(IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                line.HeaderId = this.HeaderId;
                this.Lines.Add(line);
            }
            return this;
        }
    }
    public class Line
    {
        static int _lineIdSeed = 0;
        public int LineId { get; internal set; } = _lineIdSeed++;
        public int HeaderId { get; internal set; }
    }
