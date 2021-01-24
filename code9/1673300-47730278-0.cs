    public class MyTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Parent.SelectNextControl(this, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true; // suppress Ding sound
            }
            base.OnKeyDown(e);
        }
    }
