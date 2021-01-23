    namespace YourNameSpace
    {
        public class CustomTextBox : TextBox
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (e.KeyCode == Keys.Enter && (!Multiline || Multiline && !e.Shift))
                {
                    SendKeys.Send("{TAB}");
                    // Removes "ding" sound by NOT passing the key down to container
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
