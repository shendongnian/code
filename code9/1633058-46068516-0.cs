    foreach (Operation op_ass in ListOpAss1)
       {
           op_ass.getNom(Properties.Settings.Default.Langue);
           ListViewItem item = new ListViewItem(op_ass.Nom);
           item.Tag = op_ass;
           
           // Add the list view item instead of op_ass.Nom
           listBoxAss1.Items.Add(item);
       }
