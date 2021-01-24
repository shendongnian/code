    List<string> valueArray = new List<string>();
    for (int i = 0; i < GridView4.Rows.Count; i++)
    {
        // Label1 is ID of your control in GridView
        string value = ((Label)GridView4.Rows[i].Cells[1].FindControl("Label1")).Text;
        valueArray.Add(value);
    }
    TextBox2.Text = string.Join<string>(",", valueArray); // seperate values by ,
