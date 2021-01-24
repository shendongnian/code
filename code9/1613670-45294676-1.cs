            try
            {
                listBox1.Items.AddRange(Directory.GetDirectories("C:\\Users\\", "*", SearchOption.AllDirectories));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                SomeListBox.Items.Add(ex.Message.Replace("Access to the path '", "").Replace("' is denied.", ""));
            }
