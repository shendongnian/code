    private void comboBox1_TextUpdate(object sender, EventArgs e)
    {
        string filter_param = comboBox1.Text;
        List<string> filteredItems = arrProjectList.FindAll(x => x.Contains(filter_param));
        // another variant for filtering using StartsWith:
        // List<string> filteredItems = arrProjectList.FindAll(x => x.StartsWith(filter_param));
        comboBox1.DataSource = filteredItems;
        if (String.IsNullOrWhiteSpace(filter_param))
        {
            comboBox1.DataSource = arrProjectList;
        }
        comboBox1.DroppedDown = true;
        // this will ensure that the drop down is as long as the list
        comboBox1.IntegralHeight = true;
        // remove automatically selected first item
        comboBox1.SelectedIndex = -1;
        comboBox1.Text = filter_param;
        // set the position of the cursor
        comboBox1.SelectionStart = filter_param.Length;
        comboBox1.SelectionLength = 0;            
    }
