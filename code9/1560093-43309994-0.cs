    public interface IUpgradeable
    {
        IUpgrade UpgradeEntity { get; }
    }
    public interface ISomeUpgrade : IUpgrade
    {
        // ...
    }
    public interface IUpgrade
    {
        // ...
    }
    public class SomeClass : IUpgradeable
    {
        IUpgrade IUpgradeable.UpgradeEntity => SomeUpgrade;
        public ISomeUpgrade SomeUpgrade { get; }
    }
