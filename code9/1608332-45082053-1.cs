            private void GetTextBoxValueFromCurrentTabPage()
            {
                List<string> lstTextBoxData = new List<string>();
                foreach (var textBox in tabControl1.TabPages[tabControl1.SelectedIndex].Controls.OfType<TextBox>())
                {
                    lstTextBoxData.Add(textBox.Text.Trim());
                }
            }
    
            private void GetTextBoxValueFromAllTabPages()
            {
                List<string> lstTextBoxData = new List<string>();
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    foreach (var textBox in tabPage.Controls.OfType<TextBox>())
                    {
                        lstTextBoxData.Add(textBox.Text.Trim());
                    }
                }
            }
