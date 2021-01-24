        private void dataGridMaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(DataRowView rv in e.AddedItems)
            {
                Debug.WriteLine("Row contents:");
                foreach (object d in rv.Row.ItemArray)
                {
                    Debug.WriteLine("\t" + d.ToString());
                }
            }
        }
