    step1.Visible = true; 
    
    // Below 3 lines are not necessary. Use it only if DoEvents() doesn't work.
    //step1.Invalidate();
    //step1.Update();
    //step1.Refresh();
    
    // Will process the pending request of step1.Visible=true;
    Application.DoEvents();
    
    Thread.Sleep(5000);
    step1.Visible = true;
