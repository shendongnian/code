        bool _changing = false; // since you are going to change Text you need this to stop a loop or other errors
        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_changing)
                return;
            _changing = true;
            TextBox tb = (TextBox)sender;
            string text = tb.Text.ToUpper();
            if (text == null || text.Length == 0)
            {
                // The user has not enter enough characters yet
                return;
            } 
            int num;
            if (int.TryParse(text, out num))
            {
                // it is an integer. Simply add a C at the begining if it has enough characters
                if (text.Length == 6)
                {
                    tb.Text = 'C' + text;
                    tb.CaretIndex = tb.Text.Length;
                }
                else
                {
                    // let use to continue typing
                }
            }
            else
            {
                // it is not an integer
                //check if it starts with P or C
                if (text[0] == 'C' || text[0] == 'P')
                {
                    string textrest = text.Remove(0, 1);
                    if (textrest.Length == 0)
                    {
                        // it is just a C or P
                        return;
                    }
                    if (int.TryParse(textrest, out num))
                    {
                        // it became an integer after removing the first char. It is OK then.
                    }
                    else
                    {
                        // it is not a number and removing the first C or P did not solve the problem
                        // throw new FormatException();
                        // or
                        MessageBox.Show("Wrong Format. Enter ###### or C###### or P#######");
                    }
                }
                else
                {
                    // it is not a number and the reason is not because it starts with C or P
                    // throw new FormatException();
                    // or
                    MessageBox.Show("Wrong Format. Enter ###### or C###### or P#######");
                }
            }
            _changing = false;
        }
