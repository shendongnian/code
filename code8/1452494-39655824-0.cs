        //Lets look from here if pageant is open or not. 
        
        while(true)
        {
            if (Process.GetProcessesByName("pageant").Length >= 1)
            {
                 //block your controls or whatsoever.
                 break;
            }
        }
        
        //pageant is open 
    
        while(true)
        {
             if (!Process.GetProcessesByName("pageant").Length >= 1)
             {
                 //enable controls again
                 break;
             }
        }
    
        //close thread
