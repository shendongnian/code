           public static bool IsVisible(TableItem tableItem, 
                      IEnumerable<TableItem> table)
           {
            if (tableItem.PrID == 0)
                return tableItem.Visibility;
            else
            {
                var parent = table.FirstOrDefault(x => x.ID == tableItem.PrID);
                return IsVisible(parent, table);
               
            }
          
        }
       var visibles = table.Where(x => IsVisible(x, 
                                  table.AsEnumerable())).ToList(); 
           
