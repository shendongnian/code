    public void PopulateListView()
            {
                UI_LV_Words.Clear();
                UI_LV_Words.Columns.Add("Key");
                UI_LV_Words.Columns.Add("Value");
                foreach (KeyValuePair<string, int> pair in _wordDic)
                {
                    UI_LV_Words.Items.Add(pair.Key).SubItems.Add(pair.Value.ToString());
                }
            }
