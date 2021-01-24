    foreach (Control cb in columnpanel1.Controls)
            {
                if (cb is CheckBox)
                {
                    CheckBox c = (CheckBox)cb;
                    if (c.Checked)
                    {
                        string s = c.Text;
                    }
                }
            }
