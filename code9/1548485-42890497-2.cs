        private void ClearTextBoxes()
        {
            foreach (Control control in Controls)
            {
                ClearTextBox(control);
            }
        }
        private void ClearTextBox(Control control)
        {
            if (control.GetType() == typeof(TextBox))
            {
                if (control.Name.StartsWith("textBox") && !control.Name.EndsWith("13"))
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Clear();
                }
            }
            else if (control.GetType() == typeof(GroupBox))
            {
                GroupBox groupBox = (GroupBox)control;
                foreach (Control groupBoxControl in groupBox.Controls)
                {
                    ClearTextBox(groupBoxControl);
                }
            }
        }
