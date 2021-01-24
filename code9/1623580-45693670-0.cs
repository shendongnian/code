     public static void copySourceList(ListView source, ListView target)
     {
         foreach (ListViewItem item in source.Items)
         { 
            ListViewItem temp = (ListViewItem)item.Clone();
            target.Items.Add(temp);
         }
     }
