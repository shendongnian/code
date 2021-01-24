    integer rate = 20;
    DateTime dueTime = DateTime.Now.AddMillisconds(rate);
    while(true){
      if(DateTime.Now >= dueTime){
        //insert code here
    	
    	//Update DueTime
    	dueTime = DateTime.Now.AddMillisconds(rate);
      }
      else{
        //Just yield to not tax out the CPU
        Thread.Sleep(1);
      }
    }
