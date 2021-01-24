    listView.View = View.Details;
    listView.GridLines = true; //same ways set up other props accordingly
    //now add columns
    listView.Columns.Add("Name", 100, HorizontalAlignment.Left);
    listView.Columns.Add("Houdbaarheids Datum", 100, HorizontalAlignment.Left);
    listView.Columns.Add("Locatie", 100, HorizontalAlignment.Left);
    for (int i = 0; i < products.Count; i++)
    {
          // Define the list items
          ListViewItem prd = new ListViewItem(products[i].Name);
          prd.SubItems.Add(products[i]._HoudbaarheidsDatum);
          prd.SubItems.Add(products[i]._Locatie);
          // Add the list items to the ListView
          listView.Items.Add(prd);
    }
    
