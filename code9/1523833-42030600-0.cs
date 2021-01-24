    public class BaseForm : Form
    {
    
        public void override OnShown()
        {
           base.OnShown();
           SetFoucsOnFirstInput(); 
        }
    
        public void SetFoucsOnFirstInput()
        {
            var firstInput = this.Controls.OfType<TextBox>().FirstOrDefault();
            if (firstInput != null)
                firstInput.Focus();
        }
    }
