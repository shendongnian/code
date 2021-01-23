    // new interface
    interface IRiskBaseCollection<out T>
    {
        // interface members
    }
    public abstract class RiskBaseCollection<T> : IRiskBaseCollection<T> 
        where T : RiskBase, new() 
    {
        // ...
        thisRisk.Owner = this;  // this now compiles!
    }
    public class RiskBase
    {
        public IRiskBaseCollection<RiskBase> Owner { get; set; }    // interface reference
        // ...
    }
