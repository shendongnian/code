    for (int i = 1; i <= number_MaxSemester; i++)
    {
      TabItem item = new TabItem();
      // Name of TabItem
      item.Header = i + ". Semester";
      //Contains the Data from Database
      item.Content = loadTable();
      Tabs.Items.Add(item);
    }
