     if (txtSearch.Text != "")
        {
            List<int> indexes = new List<int>();
            for (int i = listPeople.Items.Count - 1; i >= 0; i--)
            {
                var item = listPeople.Items[i];
                if (item.Text.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                }
                else
                {
                    indexes.add(i);
                }
            }
            foreach(int index in indexes)
            {
                  //delete with index
            }
            if (listPeople.SelectedItems.Count > 0)
            {
              
                listPeople.Focus();
                people.RemoveAt(listPeople.SelectedItems[0].Index);
                listPeople.Items.Remove(listPeople.SelectedItems[0]);
            }
