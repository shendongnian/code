    public class CustomTextBox : TextBox
    {
        public enum CustomOptions
        {
            Option1,
            Option2,
            Option3
        }
        private CustomOptions _CustomOption = CustomOptions.Option1;
        public CustomOptions CustomOption
        {
            get
            {
                return _CustomOption;
            }
            set
            {
                _CustomOption = value;
                switch(_CustomOption)
                {
                    case CustomOptions.Option1:
                        TextAlign = HorizontalAlignment.Center;
                        ForeColor = Color.Red;
                        break;
                    case CustomOptions.Option2:
                        TextAlign = HorizontalAlignment.Right;
                        ForeColor = Color.Black;
                        break;
                    case CustomOptions.Option3:
                        TextAlign = HorizontalAlignment.Left;
                        ForeColor = Color.Blue;
                        break;
                }
            }
        }
    }
