    bool isMouseDown = false;
    
    private void salmonToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
    { 
    	isMouseDown = true;
    }
    
    private void salmonToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
    { 
    	isMouseDown = false;
    }
    
    private void salmonToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
    {
    	if(isMouseDown)
    	{
    		//Do your thing
    	}
    }
