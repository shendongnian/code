        private void listView1_DrawColumnHeader(object sender, 
                                                DrawListViewColumnHeaderEventArgs e)
        {
            if (lvHeaderBounds == null || lvHeaderBounds.Count == listView1.Columns.Count)
                lvHeaderBounds = new List<Rectangle>();
            lvHeaderBounds.Add(e.Bounds);
        }
