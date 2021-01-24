    public partial class CustomButton : Button
    {
        public CustomButton()
        {
            BackColor = Color.FromArgb(0, 135, 190);
            ForeColor = Color.Black;
        }
    
        [Description("Test text displayed in the textbox"), Category("Data")]
        public string TextSet
        {
            set { Text = value; }
            get { return Text; }
        }
    }
