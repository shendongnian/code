    [ToolboxBitmap(typeof(TextBox))]
    public class TextBoxPro
        : TextBox
    {
        static NumberFormatInfo       s_numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
        public static readonly string s_decimalSeparator = s_numberFormatInfo.NumberDecimalSeparator;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (ReadOnly)
                return;
            var keyChar   = e.KeyChar;
            var keyString = keyChar.ToString();
            if (keyString == s_decimalSeparator)
            {
                if (IsAllSelected)
                {
                    e.Handled      = true;
                    Text           = "0.";
                    SelectionStart = 2;
                }
                else if (Text.Contains(s_decimalSeparator))
                    e.Handled = true;
            }
        }
        private bool IsAllSelected
        {
            get { return SelectionLength == TextLength; }
        }
    }
