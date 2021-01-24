        [DelimitedRecord(",")]
        [IgnoreEmptyLines()]
        [ConditionalRecord(RecordCondition.ExcludeIfBegins, "A")] 
        public class ConditionalType1 
        { 
           /// etc.
        }
