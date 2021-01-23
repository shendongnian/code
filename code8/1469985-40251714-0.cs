            private void InitialPopulation()
            {
                var listOfItems = new List<ListViewItem>();
    
                for (int i = 0; i < engine.maxPlayers; i++)
                {
                    engine.enemy[i].readInfo(i);
    
                    var item = new ListViewItem(i.ToString());
                    item.Name = engine.enemy[i].name;
                    item.SubItems.Add(engine.enemy[i].name);
                    item.SubItems.Add(engine.enemy[i].getRank);
                    item.SubItems.Add(engine.enemy[i].Wins);
                    item.SubItems.Add(engine.enemy[i].health);
                    item.SubItems.Add(engine.enemy[i].armor);
    
                    listOfItems.Add(item);
                }
    
                listView1.BeginUpdate();
                listView1.Items.Clear();
                listView1.Items.AddRange(listOfItems.ToArray());
                listView1.EndUpdate();
            }
    
            private void RefreshData()
            {
                listView1.BeginUpdate();
                var listOfItems = new List<ListViewItem>();
                var playersNames = new List<string>();
                var itemsNames = new List<string>();
    
    
                for (int i = 0; i < engine.maxPlayers; i++)
                {
                    engine.enemy[i].readInfo(i);
    
                    playersNames.Add(engine.enemy[i].name);
    
                    var items = listView1.Items.Find(engine.enemy[i].name, false);
    
                    switch (items.Length)
                    {
                        case 1: // update
                            items[0].SubItems[0].Text = engine.enemy[i].name;
                            items[0].SubItems[1].Text = engine.enemy[i].getRank;
                            items[0].SubItems[2].Text = engine.enemy[i].Wins;
                            items[0].SubItems[3].Text = engine.enemy[i].health;
                            items[0].SubItems[4].Text = engine.enemy[i].armor;
                            break;
    
                        case 0: // add
                            var item = new ListViewItem(i.ToString());
                            item.Name = engine.enemy[i].name;
                            item.SubItems.Add(engine.enemy[i].name);
                            item.SubItems.Add(engine.enemy[i].getRank);
                            item.SubItems.Add(engine.enemy[i].Wins);
                            item.SubItems.Add(engine.enemy[i].health);
                            item.SubItems.Add(engine.enemy[i].armor);
                            listOfItems.Add(item);
                            break;
                    }
                }
    
    
                if (listOfItems.Count > 0)
                    listView1.Items.AddRange(listOfItems.ToArray());
    
                foreach (ListViewItem item in listView1.Items)
                    itemsNames.Add(item.Name);
    
    
                // check if there are more listview items than data.
                if (itemsNames.Count > playersNames.Count)
                    foreach (var name in itemsNames.Except(playersNames))
                        listView1.Items.RemoveByKey(name);
    
                listView1.EndUpdate();
            }
