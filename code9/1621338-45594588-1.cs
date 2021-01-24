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
        
            //only validating if "add"-Button is pressed
            if (form[_buttonName] != null)
            {
                return base.IsValid(value);
            }
            //When no "add"-Button is pressed, no validation is needed
            return true;
        }
    }
