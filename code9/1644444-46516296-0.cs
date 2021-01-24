    public static void LoadAll(ListView listView)
    {
        List<database> users = database.GetUsers();
        listView.Items.Clear();
        foreach (database u in users)
        {
            ListViewItem item = new ListViewItem(new String[] { u.Id.ToString(), u.Username, u.Password });
            item.Tag = u;
            listView.Items.Add(item);
        }
    }
