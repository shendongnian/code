       [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);
        public void Foo()
        {
            uint localeUS = 0x00000409;
            uint localeNL = 0x00000403;
            SetSystemDefaultInputLanguage(localeUS);
        }
        public bool SetSystemDefaultInputLanguage(uint locale)
        {
            return SystemParametersInfo(SPI_SETDEFAULTINPUTLANG, 0, ref locale, 0);
        }
        public uint GetSystemDefaultInputLanguage()
        {
            uint result = uint.MinValue;
            bool retVal = SystemParametersInfo(SPI_GETDEFAULTINPUTLANG, 0, ref result, 0);
            return result;
        }
