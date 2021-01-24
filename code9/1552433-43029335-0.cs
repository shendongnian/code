     DialogResult result1 = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result1 == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;
                    try
                    {
                        string line;
                        // Read the file and display it line by line.
                        System.IO.StreamReader file1 =
                           new System.IO.StreamReader(file, true);
                        while ((line = file1.ReadLine()) != null)
                        {
                            richTextBox1.LoadFile(file,RichTextBoxStreamType.PlainText);
                        }
                        richTextBox1.Clear();
                        file1.Close();
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("The file could not be read:");
    
                    }
                }
