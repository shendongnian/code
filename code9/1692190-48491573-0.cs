    integer interval = 20;
    DateTime dueTime = DateTime.Now.AddMillisconds(interval);
    while(true){
      if(DateTime.Now >= dueTime){
        //insert code here
    	//Update next dueTime
    	dueTime = DateTime.Now.AddMillisconds(interval);
      }
      else{
        //Just yield to not tax out the CPU
        Thread.Sleep(1);
      }
    }
