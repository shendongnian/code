    [Flags]
    public enum BitFields : byte {
        None             =      0,
        VesselPresenceSw = 1 << 0,
        DrawerPresenceSw = 1 << 1,
        PumpState        = 1 << 2,
        WaterValveState  = 1 << 3,
        SteamValveState  = 1 << 4,
        MotorDriverState = 1 << 5
    }
