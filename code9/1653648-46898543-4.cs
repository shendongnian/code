    private List<string> ls = new List<string>();
    private void Add_Click(object sender, EventArgs e)
    {
        string add = textBox1.Text;
        // Avoid adding same item twice
        if (!ls.Contains(add)) {
            ls.Add(add);
        }
        RefreshListBox();
    }
    private void Delete_Click(object sender, EventArgs e)
    {
        ls.Clear();
        RefreshListBox();
    }
    private void RefreshListBox()
    {
        List.DataSource = null;
        List.DataSource = ls;
    }
