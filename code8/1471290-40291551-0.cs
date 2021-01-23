    public class RichText
    {
        #region Text Property
        private String _text = "";
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion Name Property
        #region FontStyle Property
        private FontStyle _fontStyle = FontStyles.Normal;
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set { _fontStyle = value; }
        }
        #endregion FontStyle Property
    }
