    public class MaskedTextBoxWithBorder : UserControl
    {
        MaskedTextBox maskedtextBox;
        // Other existing code...
        
        public string Mask
        {
            get { return maskedtextBox.Mask; }
            set { maskedtextBox.Mask = value; }
        }
        
        // Do same thing for other properties you want to change...
    }
