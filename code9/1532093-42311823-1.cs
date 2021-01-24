      foreach (string item in removedList)
    {
            var toRemove =listView1.Items.Find(item);
            if (toRemove != null)
            {
               listView1.Items.Remove(toRemove);
            }
    }
