        public abstract class RuleAction
        {
            public string Value { get; set; } = null;
            public decimal Percent { get; set; } = null;
        }
        public class RuleAction1 : RuleAction
        {            
        }
        public class RuleAction2 : RuleAction
        {            
        }
