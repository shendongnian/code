    public sealed class Strength : PrimaryAttribute
    {
        protected override string AttributeName => "Strength";
    }
    
    public sealed class Stamina : PrimaryAttribute
    {
        protected override string AttributeName => "Stamina";
    }
    
    public sealed class Accuracy : ProbabilisticAttribute
    {
        protected override string AttributeName => "Accuracy";
    }
    
    public sealed class Initiative : LogisticalAttribute
    {
        protected override string AttributeName => "Initiative";
    }
