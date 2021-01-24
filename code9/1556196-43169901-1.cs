    private void btnSort_Click(object sender, EventArgs e)
            {
                //Convert to utf8
                
                string[] Accounts = File.ReadAllLines(filePath, Encoding.UTF7); // if null do something
                
                foreach (string account in Accounts)
                {
                    ListViewItem lvi = new ListViewItem(account);
                    listView1.Items.Add(lvi);
                }
                
            }
