    /// <summary>
    /// C Bits field emulation of a 8 bit value
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct LiveDataBitField
    {
        // Used to set the whole field only
        [FieldOffset(0)] private byte _wholeField;
        
        /// <summary>
        /// Setter (whole)
        /// </summary>
        /// <param name="value">ushort value</param>
        public void Set(byte value)
        {
            _wholeField = value;
        }
        /// <summary>
        /// Getter (whole)
        /// </summary>
        public byte WholeField => _wholeField;
        
        [FieldOffset(0)] 
        private byte _vesselPresenceSw;
        public bool VesselPresenceSw
        {
            get => (_vesselPresenceSw & 0x1) > 0;
            set => _vesselPresenceSw |= (byte)(value ? 1 : 0);
        }
        [FieldOffset(0)] 
        private byte _drawerPresenceSw;
        public bool DrawerPresenceSw
        {
            get => (_drawerPresenceSw & 0x2) >> 1 > 0;
            set => _drawerPresenceSw |= (byte) (value ? 1 : 0 << 1);
        }
        [FieldOffset(0)] 
        private byte _pumpState;
        public bool PumpState
        {
            get => (_pumpState & 0x4) >> 2 > 0;
            set => _pumpState |= (byte) (value ? 1 : 0 << 2);
        }
        [FieldOffset(0)] 
        private byte _waterValveState;
        public bool WaterValveState
        {
            get => (_waterValveState & 0x8) >> 3 > 0;
            set => _waterValveState |= (byte) (value ? 1 : 0 << 3);
        }
        [FieldOffset(0)] 
        private byte _steamValveState;
        public bool SteamValveState
        {
            get => (_steamValveState & 0x10) >> 4 > 0;
            set => _steamValveState |= (byte)(value ? 1 : 0 << 4);
        }
        [FieldOffset(0)] 
        private byte _motorDriverState;
        public bool MotorDriverState
        {
            get => (_motorDriverState & 0x20) >> 5 > 0;
            set => _motorDriverState |= (byte)(value ? 1 : 0 << 5);
        }
    }
