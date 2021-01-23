    const string password = "123456789";    //just an example password
    
                string url = textBox1.Text;
    
                // Get if the user entered the right password
                GetPass pass = new GetPass(password);
    
                // Check this with a dialog result
                DialogResult result = pass.ShowDialog();
    
                if (result == DialogResult.OK)
                {
                        BlockList.Add(url);
                        MessageBox.Show("Added " + url + " to blocklist.");
                        textBox1.Clear();
    
                }
