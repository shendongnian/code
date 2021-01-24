    public class Rule
    {
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public override string ToString()
        {
            return string.Format("{0}: {1}", RuleName, RuleDescription);
        }
    }
