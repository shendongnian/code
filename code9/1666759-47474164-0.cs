            string[] files = Directory.GetFiles("plugins/");
            string fileName = Path.GetFileNameWithoutExtension(file);
            foreach (string file in files)
            {
                var item = new ListViewItem();
                item.Tag = file;
                item.Text = fileName;
                listView1.Items.Add(item);
            }
          
