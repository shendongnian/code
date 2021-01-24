    public static class ColorValues
    {
        // Private variable to hold font once instantiated
        private static System.Drawing.Color _normalFont;
        public static System.Drawing.Color NormalFont 
        {
            get
            {
                // Only instantiate when needed
                if (_normalFont == null)
                {
                    _normalFont = Color.AliceBlue;         
                }
                return _normalFont;
            }
        }
    }
