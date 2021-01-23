    private void AddLVItem(string key, string name, int value)
    { 
        ListViewItem lvi = new ListViewItem();
        ProgressBar pb = new ProgressBar();
    
        lvi.SubItems[0].Text = name;
        lvi.SubItems.Add(value.ToString());
        lvi.SubItems.Add("");
        lvi.SubItems.Add(key);            // LV has 3 cols; this wont show
        lv.Items.Add(lvi);
    
        Rectangle r = lvi.SubItems[2].Bounds;
        pb.SetBounds(r.X, r.Y, r.Width, r.Height);
        pb.Minimum = 1;
        pb.Maximum = 10;
        pb.Value = value;
        pb.Name = key;                   // use the key as the name
        lv.Controls.Add(pb);
    }
