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
    
    // usage
    DecimalModel d = new DecimalModel();
    d.CleanUpHours = 1.0M; // CleanUpHours is a decimal here
    BucketHoursWithCalculationsModel b = new BucketHoursWithCalculationsModel();
    b.CleanUpHours = new BucketHoursWithCalculations();
    b.CleanUpHours.SomeProperty = 1.0M;
