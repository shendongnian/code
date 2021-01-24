    golbal static bool alarmSet=true;
     public main()    // or inside some button press 
     {
       Task task = new Task(new Action(Guard());
       task.Start();  // notice tasks ends when alarmset = False
     }
    private void Guard()
    { while (alarmSet)
    {
      d = detecthumidity.value;
      if (d > trigger) { sendEmail();Sleep(60000);} //only sleeps when smoke is detect but will continously check
      sleep(100); //maybe your sensor needs some rest time as well. (like arduino DAC)
    }
    }
    
