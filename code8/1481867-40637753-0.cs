        private void saveToFile_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("C:\\k\\saveToFile.txt", true))
            {
                if (this.Controls.Count > 0)
                {
                    var textBoxes = this.Controls.OfType<TextBox>();
                    foreach (TextBox textbox in textBoxes)
                    {
                        writer.WriteLine(textbox.Name + "=" + textbox.Text);
                    }
                }
            }
        }
