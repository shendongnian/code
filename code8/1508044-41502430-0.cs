    public void RunLoopTwice(){
        MyLoop();
        MyLoop(); 
    }
    
    public void Myloop()
    {
        bool execute = true;
        while (execute == true)
        {
            // do some stuff
            if (condition)
            {
                execute = false;
            }
        }
    }
