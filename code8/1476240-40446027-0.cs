    public class MyForm : Form
    {
        private string _LastInsertedText;
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if(textbox.Text.Equals(_LastInsertedText))
            {
                // notify about same value
            }
            else
            {
                _LastInsertedText = textbox.Text
            }
        }
    }
