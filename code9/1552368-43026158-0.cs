    foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (!String.IsNullOrEmpty(c.Text))
                    {
                        preset_lines[19] = c.Text;
                    }
                }
            }
