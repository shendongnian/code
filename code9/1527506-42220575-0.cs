    private void button8_Click(object sender, EventArgs e)
    {
        List<object> list= new List<object>();
        foreach (object item in checkedListBox1.CheckedItems)
        {
            list.Add(item.ToString());
        }
        // Assign List to Element to display
        //e.g Listbox
        //Listbox1 lbOx1 = new ListBox();
        //lbOx1.Text= list
    }
