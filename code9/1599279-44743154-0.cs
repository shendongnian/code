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
            }
        }
    }
