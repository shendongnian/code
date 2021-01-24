    protected void btnadd_Click(object sender, EventArgs e)
    {
        int num;
        num = Convert.ToInt32(txtnumber.Text.Trim());
        int addedColumn = Convert.ToInt32(columnAdded.Value);
        for (int i = addedColumn + 1; i <= addedColumn + num; i++)
        {
            string name = "Unit";
            name = string.Concat(name, i);
            TemplateField test = new TemplateField();
            test.HeaderText = name;
            test.ItemTemplate = new TemplateHandler (); // ** This line to set ItemTemplate is missing in the code you posted
            GridView1.Columns.Add(test);
           // ... Other code as you need
        }
      
    }
