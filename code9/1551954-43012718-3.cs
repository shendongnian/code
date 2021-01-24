    public sealed class Strength : PrimaryAttribute
    {
        protected override sealed string AttributeName => "Strength";
    }
    
    public sealed class Stamina : PrimaryAttribute
    {
        protected override sealed string AttributeName => "Stamina";
    }
    
    public sealed class Accuracy : ProbabilisticAttribute
    {
        protected override sealed string AttributeName => "Accuracy";
    }
    
    public sealed class Initiative : LogisticalAttribute
    {
        protected override sealed string AttributeName => "Accuracy";
    }
