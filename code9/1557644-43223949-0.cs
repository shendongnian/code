    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BiometricUnitSchema
    {
        public int UnitId;
        public BiometricPoolType PoolType;
        public BiometricType BiometricFactor;
        public BiometricSubtype SensorSubType;
        public BiometricCapabilities Capabilities;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DeviceInstanceId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Description;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Manufacturer;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Model;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string SerialNumber;
        public BiometricVersion FirmwareVersion;
    }
