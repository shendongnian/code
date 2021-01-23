    private List<string> TextBoxEmpty()
        {
            List<string> emptyTextboxes = new List<string>();
            for (int i = 1; i < 20; i++)
            {
                try
                {
                    TextBox myControl = (TextBox)Controls.Find("textBox" + i.ToString(), true)[0];
                    if (string.IsNullOrEmpty(myControl.Text))
                    {
                        emptyTextboxes.Add(myControl.Name);
                    }
                }catch
                {
                    continue;
                }
            }
            return emptyTextboxes;
        }
