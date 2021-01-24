    public static class BatteryExtensions
    {
        public static string GetBatteryName(this Battery battery)
        {
            return battery?.Name ?? "none";
        }
    }
    allDetails.Add("Conected to " + ConnectedBattery.GetBatteryName());
