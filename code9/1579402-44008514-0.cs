    private void button1_Click(object sender, EventArgs e) 
    {
        price = 500;
        quantity = Double.Parse(maskedTextBox1.Text);
        total = price * quantity;
        //The 4 lines below should only be executed one time and not every time
        //you press the button.  It was added here for illustrative purposes only.  Try adding them to the `OnLoad` method.
        this.listView1.View = View.Details;
        this.listView1.Columns.Add("Name", 100);
        this.listView1.Columns.Add("Total", 100);
        this.listView1.Columns.Add("Quantity", 100);
        //Move the above 4 lines to the `OnLoad` method.
        var listViewItem = new ListViewItem(form1.label1.Text);
        listViewItem.SubItems.Add(total.ToString());
        listViewItem.SubItems.Add(quantity.ToString());
        form1.listView1.Items.Add(listViewItem);
    }
