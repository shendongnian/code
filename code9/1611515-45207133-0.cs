        private void btnListFiles_Click(object sender, EventArgs e)
        {
            try
            {
                var fileNames = Directory.GetFiles(Directory.GetCurrentDirectory());
                foreach (var fileName in fileNames)
                {
                    // cbListBox.Items.Add(fileName); // Full path
                    cbListBox.Items.Add(fileName.Split('\\').Last()); // Just filename
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
