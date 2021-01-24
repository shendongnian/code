        /// <summary>
        /// Return the specified color code as a Int32
        /// </summary>
        public Int32 GetColor(byte r, byte g, byte b)
        { return Int32.Parse(Color.FromRgb(r, g, b).ToString().Trim('#'), System.Globalization.NumberStyles.HexNumber); }
