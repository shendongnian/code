    public static string[] GetSelectedListItems(CheckBoxList _ddl)
         {
         List<string> GetData = new List<string>();
    
         foreach (ListItem item in _ddl.Items)
         {
            if (item.Selected) GetData.Add(item.Text);
         }
    
         return GetData.ToArray();
        }
