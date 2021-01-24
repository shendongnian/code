            foreach (Control c in this.Controls)
            {
                if (c is TextBox && (string)c.Tag != "DoNotUnlock")
                {
                    ((TextBox)c).ReadOnly = false;
                    ((TextBox)c).BackColor = Color.FromArgb(255, 255, 192);
                }
            }
