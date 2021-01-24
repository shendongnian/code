    public ListView _ListView {
         get { return this.listView1; }
    }
    private void button1_Click(object sender, EventArgs e){
        Form2 frm = new Form2(this);
        frm.productName = listView1.Items[listView1.SelectedItems[0].Index].SubItems[0].Text; // set defined variable value (for example, index of subitems 0 represents ProductName)
        frm.Show();    
    }
