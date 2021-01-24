        var sectionCharacters = File.ReadAllLines("bdaylist.list").Where(s => s != "==").ToList();            
            for (int i = 0; i < sectionCharacters.Count; i++)
            {
                if (i % 2 == 0)
                {
                    var lvi = new ListViewItem { Text = sectionCharacters[i] };
                    lvi.SubItems.Add(sectionCharacters[i + 1]);
                    listView1.Items.Add(lvi);
                }
            }
