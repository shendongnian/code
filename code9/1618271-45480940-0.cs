    public class BuildInfo
    {
        private static BuildInfo _buildInfo;
    
        private BuildInfo()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
            {
                Build = Build.FallCreators;
            }
            else if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 4))
            {
                Build = Build.Creators;
            }
            else if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 3))
            {
                Build = Build.Anniversary;
            }
            else if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 2))
            {
                Build = Build.Threshold2;
            }
            else if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 1))
            {
                Build = Build.Threshold1;
            }
            else
            {
                Build = Build.Unknown;
            }
        }
    
        public static Build Build { get; private set; }
    
        public static BuildInfo RetrieveBuildInfo() => _buildInfo ?? (_buildInfo = new BuildInfo());
    }
    
    public enum Build
    {
        Unknown = 0,
        Threshold1 = 1507,   // 10240
        Threshold2 = 1511,   // 10586
        Anniversary = 1607,  // 14393 Redstone 1
        Creators = 1703,     // 15063 Redstone 2
        FallCreators = 9999  // ????? Redstone 3
    }
