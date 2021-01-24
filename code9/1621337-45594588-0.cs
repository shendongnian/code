    public class ButtonRequiredAttribute : RequiredAttribute
    {
        private readonly string _buttonName;
        public ButtonRequiredAttribute(string buttonName)
        {
            _buttonName = buttonName;
        }
        public override bool IsValid(object value)
        {
            var form = HttpContext.Current.Request.Form;
            if (form[_buttonName] != null)
            {
                return base.IsValid(value);
            }
            return true;
        }
    }
