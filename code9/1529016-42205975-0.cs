            public void ResetAllTextBoxes()
            {
                foreach (Control control in this.Controls)
                    if (control is TextBox)
                        control.ResetText();
            }
