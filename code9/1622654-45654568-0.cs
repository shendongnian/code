        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.cboCollection != null)
                this.cbx_unix_dir.Items.AddRange(Settings.Default.cboCollection.ToArray());
        }
    
    
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArrayList arraylist = new ArrayList(this.cbx_unix_dir.Items);
            Settings.Default.cboCollection = arraylist;
            Settings.Default.Save();
        }
    
        //A button to add items to the ComboBox
        private void button2_Click_1(object sender, EventArgs e)
        {
            cbx_unix_dir.Items.Add(cbx_unix_dir.Text);
        }
