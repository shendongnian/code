    public abstract class PrimaryAttribute : AttributeBase
    {
        protected override sealed AttributeCategory Category { get; } = AttributeCategory.Primary;
    }
    
    public abstract class ProbabilisticAttribute : AttributeBase
    {
        protected override sealed AttributeCategory Category { get; } = AttributeCategory.Probabilistic;
    }
    
    public abstract class LogisticalAttribute : AttributeBase
    {
        protected override sealed AttributeCategory Category { get; } = AttributeCategory.Logistical;
    }
