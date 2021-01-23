    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
    	if (e.Button == MouseButtons.Right)
    	{
    		Point pt = e.Location;
    
    		Control ctrl = this.GetChildAtPoint(pt);
    
    		if (ctrl != null)
    		{
    			ContextMenu menu = ctrl.ContextMenu;    		  
    
    			menu.Show(ctrl, new Point(10,10));
    		}                    
    	}
    }
