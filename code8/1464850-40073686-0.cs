    private void tvTestBtn_Click(object sender, RoutedEventArgs e)
    {
      DataTable dt = (DataTable)sampleTV.DataContext;
      DataRow dr = dt.Rows.Find("Test2");
      dr.BeginEdit();
      dr.SetField(0, "Test2aaa");
      // Removes the old relation..
      ds.Relations.Remove("DummyT1_DummyT2");
      // and add it again
      ds.Relations.Add(
      new DataRelation("DummyT1_DummyT2",
        ds.Tables[0].Columns[0],
        ds.Tables[1].Columns[0]));
      dt.AcceptChanges();
      dr.EndEdit();
    }
