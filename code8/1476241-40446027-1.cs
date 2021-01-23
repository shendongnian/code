    public class MyForm : Form
    {
        private string _LastInsertedText;
        public MyForm()
        {
            thisTextBox1.Leave += TextBox_Leave;
            thisTextBox2.Leave += TextBox_Leave;
            thisTextBox3.Leave += TextBox_Leave;
        }
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
