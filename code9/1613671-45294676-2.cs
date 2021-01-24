    void getDirectories(string path)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                listBox1.Items.AddRange(directories);
                foreach(string directory in directories)
                {   
                    getDirectories(directory);
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                SomeListBox.Items.Add(ex.Message.Replace("Access to the path '", "").Replace("' is denied.", ""));
            }
        }
