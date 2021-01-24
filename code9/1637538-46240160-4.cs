    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct LiveDataBitField
    {
        // Where the values are effectively stored
        public byte WholeField { get; private set; }
        
        public bool VesselPresenceSw
        {
            get => (WholeField & 0x1) > 0;
            set
            {
                if (value)
                {
                    WholeField |= 1;
                }
                else
                {
                    WholeField &= 0xfE;
                }
            }
        }
        public bool DrawerPresenceSw
        {
            get => (WholeField & 0x2) >> 1 > 0;
            set
            {
                if (value)
                {
                    WholeField |= (1 << 1);
                }
                else
                {
                    WholeField &= 0xFD;
                }
            }
        }
        public bool PumpState
        {
            get => (WholeField & 0x4) >> 2 > 0;
            set
            {
                if (value)
                {
                    WholeField |= (1 << 2);
                }
                else
                {
                    WholeField &= 0xFB;
                }
            }
        }
        public bool WaterValveState
        {
            get => (WholeField & 0x8) >> 3 > 0;
            set
            {
                if (value)
                {
                    WholeField |= (1 << 3);
                }
                else
                {
                    WholeField &= 0xF7;
                }
            }
        }
        public bool SteamValveState
        {
            get => (WholeField & 0x10) >> 4 > 0;
            set
            {
                if (value)
                {
                    WholeField |= (1 << 4);
                }
                else
                {
                    WholeField &= 0xEF;
                }
            }
        }
        public bool MotorDriverState
        {
            get => (WholeField & 0x20) >> 5 > 0;
            set
            {
                if (value)
                {
                    WholeField |= (1 << 5);
                }
                else
                {
                    WholeField &= 0xDF;
                }
            }
        }
    }
