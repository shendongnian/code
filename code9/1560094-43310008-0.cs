    public interface IUpgradeable<TUpgrade> where TUpgrade : IUpgrade
    {
        TUpgrade UpgradeEntity{ get; }
    }
    public interface ISomeUpgrade : IUpgrade 
    {
     // ...
    }
    
    public interface IUpgrade 
    {
     // ...
    }
    
    public class SomeClass : IUpgradeable<ISomeUpgrade>
    {
        public ISomeUpgrade UpgradeEntity{ get; } 
    }
