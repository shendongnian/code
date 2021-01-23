        /// <summary>
        /// Creates a new PropVariant containing a uint value
        /// </summary>
        public static PropVariant FromUInt(uint value)
        {
            return new PropVariant() { vt = (short)VarEnum.VT_UI4, ulVal = value };
        }
