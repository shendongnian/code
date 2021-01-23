     public class HealthChecker : IHealthChecker
    {
        private readonly HealthCheckerConfig _config;
        private readonly IAssetProvider _assetProvider;
        public HealthChecker(IOptions<HealthCheckerConfig> config, IAssetProvider assetProvider)
        {
            _config = config.Value;
            _assetProvider = assetProvider;
        }
    }
