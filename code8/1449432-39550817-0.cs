    private bool TextBoxEmpty()
            {
                for (int i = 1; i < 20; i++)
                {
                    try
                    {
                        TextBox myControl = (TextBox)Controls.Find("textBox" + i.ToString(), true)[0];
                        if (string.IsNullOrEmpty(myControl.Text))
                            return true;
                    }catch
                    {
                        continue;
                    }
                }
                return false;
            }
