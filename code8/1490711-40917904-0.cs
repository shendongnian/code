       Dictionary<int, int> dictionary = new Dictionary<int, int>();
            ListViewItem track = new ListViewItem();
            dictionary.Add(0, 21);
            dictionary.Add(1, 45);
            track.Tag = dictionary;
            track.Text = ("Test: 1" + " Test: 2");
            listView1.Items.Add(track);
