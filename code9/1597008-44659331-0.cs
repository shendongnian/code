    [DefaultEvent("Click")]
    public class TextBoxButton : TextBox
    {
        public TextBoxButton()
        {
            mbutton = new Button();
            mbutton.Width = 20;
            mbutton.Cursor = Cursors.Hand;
            mbutton.Click += TextBoxButton_Click;
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(Handle, 0xd3, (IntPtr)2, (IntPtr)(mbutton.Width << 16));
        }
        private void TextBoxButton_Click(object sender, EventArgs e)
        {
            //  Raise our own Click event
            OnClick();
        }
        public event EventHandler Click;
        protected void OnClick() {
            var handler = Click;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
