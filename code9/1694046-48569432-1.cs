    //custom ChangeNofiticationHander
    busyChangeHanlder(object sender, PropertyChangedEventArgs e){
      if(e.PropertyName == "BusyBoolean"){
        if(BusyBoolean)
          //Start the timer
        else
          //Stop the timer
      }
    }
    timerTickHandler(object sender, TimerTickEventArgs e){
      if(BusyBoolean){
         //create and Dispaly the Dialog here
      }
    }
