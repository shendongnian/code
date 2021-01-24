        private void button1_Click(object sender, EventArgs e)
        {
            // When user clicks button, show the dialog.
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;
            // Write to the file name selected.
            // ... You can write the text from a TextBox instead of a string literal.
            // insert the code for the pdf here
        }
