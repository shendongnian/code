    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string filter_param = textBox1.Text;
        List<string> filteredItems = arrProjectList.FindAll(x => x.Contains(filter_param));
        // another variant for filtering using StartsWith:
        // List<string> filteredItems = arrProjectList.FindAll(x => x.StartsWith(filter_param));
        comboBox1.DataSource = filteredItems;
        // if all values removed, bind the original full list again
        if (String.IsNullOrWhiteSpace(textBox1.Text))
        {
            comboBox1.DataSource = arrProjectList;
        }
        // this line will make sure, that the ComboBox opens itself to show the filtered results
       
    }
