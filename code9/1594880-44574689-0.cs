    var waitedSoFar = 0;
    var imageDisplayed = CheckIfImageIsDisplayed(); //this function is where you check the condition
    
    while(waitedSoFar < 5000)
    {
       imageDisplayed = CheckIfImageIsDisplayed();
       if(imageDisplayed)
       {
          //success here
          break;
       }
       waitedSoFar += 100;
       Thread.Sleep(100);
    }
    if(!imageDisplayed)
    {
        //failed, do something here about that.
    }
