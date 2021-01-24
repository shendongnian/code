    public class RegexTextCalibrator
    {
        private ICollection<Tuple<Regex, string>> Calibrations = new List<Tuple<Regex, string>>();
    
        public void AddParallelPattern(IEnumerable<string> a, IEnumerable<string> b, string output)
        {
            this.AddParallelPattern(a, b, @"\W+.*", output);
        }
    
        public void AddParallelPattern(IEnumerable<string> a, IEnumerable<string> b, string inBetweenLinkPattern, string output)
        {
            string subPatternA = String.Join("|", a);
            string subPatternB = String.Join("|", b);
    
            var patternA = String.Format("({0})({1})({2})", subPatternA, inBetweenLinkPattern, subPatternB);
            var patternB = String.Format("({0})({1})({2})", subPatternB, inBetweenLinkPattern, subPatternA);
    
            this.Add(String.Format("{0}|{1}", patternA, patternB), output);
        }
    
        public void Add(string pattern, string output)
        {
            this.Add(new Regex(pattern, RegexOptions.IgnoreCase), output);
        }
    
        public void Add(Regex regex, string output)
        {
            Calibrations.Add(new Tuple<Regex, string>(regex, output));
        }
    
        public string Resolve(string value)
        {
            var calibration = this.Calibrations.FirstOrDefault(x => x.Item1.IsMatch(value));
            return calibration != null ? calibration.Item2 : null;
        }
    }
