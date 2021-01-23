    public void displayOutput(List<Item> items) {
    
    	//create panel to host dynamic content
    	Panel panel = new Panel();
    	form.Controls.Add(panel);
    	panel.AutoScroll = true;
    	panel.OnLayout += Do_Layout;
    
    	//create UI controls for each report item
    	foreach (Item item in items) {
    
    		//create a label to display the item 
    		Label l = new Label();
    		l.Text = item.Messagel
    		panel.Controls.Add(l);
    		
    		//create a button to perform the item action
    		Button b = new Button();
    		b.Text = "Do something";
    		b.Click += ... delegate to perform the action
    		panel.Controls.Add(b);
    	}
    }
    
    public void Do_Layout(object sender, EventArgs args) {
    	int y = 0;
    	Panel panel = (Panel)sender;
    	foreach (Control control in panel.Controls) {
    	
    		Size sz = control.GetPreferredSize();
    		control.Bounds = new Rectangle(0, y, sz.Width, sz.Height);
    		y += sz.Height;
    	}
    }
