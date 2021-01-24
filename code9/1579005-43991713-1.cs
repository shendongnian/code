    public static string GetBatteryName(Battery battery)
    {
        return battery?.Name ?? "none";
    }
    allDetails.Add("Connected to " + Battery.GetBatteryName(ConnectedBattery));
