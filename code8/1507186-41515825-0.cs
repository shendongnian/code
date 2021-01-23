    // use a type parameter on the base model that must be specified
    // in derived models.
    public class BaseModel<THours>
    {
        public string Title { get; set; }
        public THours CleanUpHours { get; set; }
        public THours InstallHours { get; set; }
    }
    
    // hours are specified as decimals
    public class DecimalModel : BaseModel<decimal>
    {
    }
    // hours are specified as BucketHoursWithCalculations    
    public class BucketHoursWithCalculationsModel : BaseModel<BucketHoursWithCalculations>
    {
    }
    
    // use
    DecimalModel d = new DecimalModel();
    d.CleanUpHours = 1.0;
    BucketHoursWithCalculationsModel b = new BucketHoursWithCalculationsModel();
    b.BucketHoursWithCalculations = new BucketHoursWithCalculations();
    b.BucketHoursWithCalculations.SomeProperty = 1.0;
