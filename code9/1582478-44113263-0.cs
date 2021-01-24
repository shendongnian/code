    if ((myStream = theDialog.OpenFile()) != null)
    {
        using (myStream)
        {
            using (var sr = new System.IO.StreamReader(myStream)) // Wrapped it up in a using statement so it is disposed of automagically
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null) // Loop while there is more data to read
                {
                    string[] lineItems = line.Split('|'); // Split only the single line
                    ListViewItem lv = new ListViewItem();
                    lv.Text = lineItems[0];
                    lv.SubItems.Add(lineItems[1]);
                    lv.SubItems.Add(lineItems[2]);
                    basket.Items.Add(lv);
                }
            }
        }
    }
