        ListView MainList;
        public void createlist()
        {
            MainList = new ListView();
            DisplayPanel.Controls.Add(MainList);
            MainList.View = View.Details;
            MainList.GridLines = true;
            MainList.Name = "MainList";
            MainList.Size = DisplayPanel.Size;
            int s1 = DisplayPanel.Size.Height;
            int s2 = DisplayPanel.Size.Width;
            MainList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            MainList.Columns.Add("ProductName", 100);
            MainList.Columns.Add("ProductName2", 100);
            MainList.Columns.Add("ProductName3", 100);
            MainList.Columns.Add("ProductName4", 100);
        }
        // your other method should be here...
