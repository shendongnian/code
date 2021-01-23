    protected override void OnCreateControl()
		{
			base.OnCreateControl();
			
			this.Items.Clear();
	        this.CheckBoxes = true;
	        this.HeaderStyle = ColumnHeaderStyle.None;
	        this.View = View.List;
	
	        foreach (var value in Enum.GetValues(typeof(ScrapGroup)).Cast<ScrapGroup>())
	        {
	            this.Items.Add(new ListViewItem()
	            {
	                Name = value.ToString(),
	                Text = value.ToString(),
	                Tag = value,
	            });
        	}
		}
