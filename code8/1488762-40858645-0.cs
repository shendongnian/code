    Timer objtimer;
    static void Main()
    {
         objtimer = new Timer();
         objtimer.Interval =50000;
         objtimer.Tick += objtimer_Tick;
    }
     void objtimer_Tick(object sender, EventArgs e)
     {
          // your function
     }
