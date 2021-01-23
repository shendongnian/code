    form.Show(owner);
    while(AppIsRunning){
        if(clicked)
            commit();
        else   
        {
            System.Windows.Forms.Application.DoEvents();
            // Thread.sleep(100);
        }
    }
