    static int commandsInProcessing = 0;
    void CommandReceived()
    {
       while(commandsInProcessing >= 30)
       { 
          Sleep(100);
       }
 
       commandsInProcessing++;
       ProcessCommand();
       commandsInProcessing--;
    }
