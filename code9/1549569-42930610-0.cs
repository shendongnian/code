    if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename;
                    List<string> result = new List<string>();
                    int i = 0;
                    try
                    {
                        if ((myStream = openFileDialog.OpenFile()) != null)
                        {
                            foreach (String file in openFileDialog.FileNames)
                            {
                                filename = Path.GetFileName(file);
                                result.Add(filename);
                                MessageBox.Show(result[i]); // only show the name of file
    
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk.   Original error: " + ex.Message);
                    }
                }
