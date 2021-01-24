    int left = 45;
    int idx = 0;
    for (int i = 0; i < startShapes.Count; i++)
    {
    	RadioButton rdb = new RadioButton();
    	rdb.Text = startShapes.Values.ElementAt(i).Equals("") ? startShapes.Keys.ElementAt(i) : startShapes.Values.ElementAt(i);
    	rdb.Size = new Size(100, 30);
    	this.Controls.Add(rdb);
    	rdb.Location = new Point(left, 70 + 35 * idx++);
    	if (idx == 5)
    	{
    		idx = 0; // reset row
    		left += rdb.Width + 5; // move to next column
    	}
    	rdb.CheckedChanged += (s, ee) =>
    	{
    		var r = s as RadioButton;
    		if (r.Checked)
    			this.selectedString = r.Text;
    	};
    }
