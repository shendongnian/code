           public static string IsVisible(TableItem tableItem, IEnumerable<TableItem> table)
        {
            if (tableItem.PrID == 0 || tableItem.Visibility.Equals("HIDDEN"))
                return tableItem.Visibility;
            else
            {
                var parent = table.FirstOrDefault(x => x.ID == tableItem.PrID);
                return IsVisible(parent, table);
            }
          
        }
       var visibles = table.Where(x => IsVisible(x, 
                   table.AsEnumerable()).Equals("VISIBLE")).ToList();     
           
