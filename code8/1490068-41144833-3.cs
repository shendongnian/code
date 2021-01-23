    public class Util
    {
        internal static string GetBaseServerAddress()
        {
            var configurationPackage = FabricRuntime.GetActivationContext().GetConfigurationPackageObject("Config");
            var baseServerAddress =
                configurationPackage.Settings.Sections["Configuration"].Parameters["BaseServerAddress"];
            return baseServerAddress.Value;
        }
    }
