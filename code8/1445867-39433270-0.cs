        private void LoadListView()
        {
            // Assume we are in a form, with a ListView control called listView1 on the form
            // Create a group label array
            var groupLabels = new string[5];
            groupLabels[0] = "aaa";
            groupLabels[1] = "bbb";
            groupLabels[2] = "ccc";
            groupLabels[3] = "ddd";
            groupLabels[4] = "eee";
            for (var i = 65; i < 76; i++)
            {
                // Find group or create a new group
                ListViewGroup lvg = null;
                var found = false;
                foreach (var grp in listView1.Groups.Cast<ListViewGroup>().Where(grp => grp.ToString() == groupLabels[i % 5]))
                {
                    found = true;
                    lvg = grp;
                    break;
                }
                if (!found)
                {
                    // Group not found, create
                    lvg = new ListViewGroup(groupLabels[i % 5]);
                    listView1.Groups.Add(lvg);
                }
                // Add ListViewItem
                listView1.Items.Add(new ListViewItem {Text = i.ToString(CultureInfo.InvariantCulture), Group = lvg});
            }
