    namespace YourNameSpace
    {
        public class CustomTextBox : TextBox
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{TAB}");
                // Remove annoying "ding" sound by NOT
                // passing the key down to container
                // e.SuppressKeyPress = true;
            }
        }
    }
