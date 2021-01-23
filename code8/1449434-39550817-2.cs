    private void TextBoxEmpty()
        {
            StringBuilder result = new StringBuilder();
            bool emptyTextbox = false;
            for (int i = 1; i <= 20; i++)
            {
                try
                {
                    TextBox myTextBox = (TextBox)Controls.Find("textBox" + i.ToString(), true)[0];
                    if (string.IsNullOrEmpty(myTextBox.Text))
                    {
                        MessageBox.Show(myTextBox.Name + " cannot be left empty");
                        emptyTextbox = true;
                        continue;
                    }
                    result.Append(myTextBox.Text + Environment.NewLine);
                }
                catch
                {
                    continue;
                }
            }
            if (!emptyTextbox)
                MessageBox.Show(result.ToString());
        }
