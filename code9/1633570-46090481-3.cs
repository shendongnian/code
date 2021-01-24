    public class xTextBox : TextBox
    {
        public xTextBox()
        {
            BorderStyle = BorderStyle.None;
            Text = "My Default Text";
        }
        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
