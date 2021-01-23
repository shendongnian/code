    public static void GetFocusOfSelectedRow(DataGrid datagrid)
        {
            ItemCollection items = datagrid.Items;
            List<SomeType> collection = new List<SomeType>();
            foreach (var item in items)
            {
                SomeType obj = item as SomeType ;
                if(obj != null)
                    collection.Add(obj);
            }
            SomeType result = collection.Where(a => a.SomeProperty == SomeValue)
                .FirstOrDefault();
            datagrid.SelectedItem = result;
            datagrid.ScrollIntoView(result);
        }
