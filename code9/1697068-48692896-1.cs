    static void CallTimer(object state){
            bool Lock = false;
            try{
                Lock = Monitor.TryEnter(timerLck);
                if (Lock){
                    Program Prg = new Program()
                    var task = Task.Run(()=>Run(PreviousErrors));
                    PreviousErrors = task.Result;
                }
            }
        finally{
            if (Lock) Monitor.Exit(timerLck);
        }
    }
