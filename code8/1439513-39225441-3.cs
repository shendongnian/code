    DateTime? sg = null;
    if(gridView1.GetDataRow(i)["date"] != DBNull.Value)
       sg = Convert.ToDateTime(gridView1.GetDataRow(i)["date"]);
    
    if (!repositoryItemComboBox1.Items.Contains(sg))
    {
       repositoryItemComboBox1.Items.Add(sg);
    }
