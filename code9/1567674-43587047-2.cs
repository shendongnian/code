        public static bool IsVisible(TableItem tableItem)
        {
            if (tableItem.PrID == 0)
                return tableItem.Visibility;
            else
            {
                var parent = table.FirstOrDefault(x => x.ID == tableItem.PrID);
                return IsVisible(parent);
            }
          
        }
        
        static List<TableItem> table = new List<TableItem>();
        var visibles = table.Where(x => IsVisible(x)).ToList();
