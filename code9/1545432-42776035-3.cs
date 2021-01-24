            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column header
            listView1.Columns.Add("Status", 70);
            listView1.Columns.Add("Country", 70);
            listView1.Columns.Add("Link", 399);
            string[] countriesCodes = new string[] { "test1", "test2", "test3" };
            string[] arr = new string[countriesCodes.Length];
            ListViewItem itm;
            for (int i = 0; i < countriesCodes.Length; i++)
            {
                arr[0] = "Ready";
                arr[1] = countriesCodes[i];
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
            colorReady();
