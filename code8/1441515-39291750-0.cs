    System.Timers.Timer[] timerMatrix = new System.Timers.Timer[40];
    for(int i=0; i < 40; i++){
        timerMatrix[i] = new System.Timers.Timer() {
            Enabled = true,
            Interval = 10
        };
        
        Elapsed += Timermatrix_Elapsed;
    }
    private void Timermatrix_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
         .....
    }
