    public class ValidationService
    {
        public void RegisterRules(Control control, string[] rules)
        {
            // store rules
        }
    
        public string[] GetRules(Control control)
        {
            // retrieve rules
        }
    
        public void Validate(Control control)
        {
            // validate
        }
    }
    
    public interface IValidatable
    {
        ValidationService ValidationService { get; set; }
        string[] Rules { get; set; }
        void ValidateControl();
    }
    
    public class MyTextBox : TextBox, IValidatable
    {
        public ValidationService ValidationService { get; set; }
    
        public string[] Rules
        {
            get => ValidationService.GetRules(this);
            set => ValidationService.RegisterRules(this, value);
        }
    
        public void ValidateControl()
        {
            ValidationService.Validate(this);
        }
    }
    
    public class MyNumericUpDown : NumericUpDown, IValidatable
    {
        public ValidationService ValidationService { get; set; }
    
        public string[] Rules
        {
            get => ValidationService.GetRules(this);
            set => ValidationService.RegisterRules(this, value);
        }
    
        public void ValidateControl()
        {
            ValidationService.Validate(this);
        }
    }
