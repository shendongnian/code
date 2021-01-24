    private void btnAddEntry_Click(object sender, EventArgs e)
        {
            string hoster = textBox1.Text;
            ne.addNewEntry(mainForm.Bs, 1, hoster);
            mainForm.RefreshDGV();
            this.Close();
        }
 
   
 
    
