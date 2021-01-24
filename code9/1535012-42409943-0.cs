        int countTime;
        bool breakReached;
        int breakTime;
        int breakLength;
        int countToFinish;
        int finishTime;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            breakTime = 300; // in sek
            breakLength = 120; // in sek
            finishtime = 1200;
            breakReached = false;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (countTime != breakTime && breakReached != true)
            {
                progressBar1.Increment(1);
                progressBar1.Text = progressBar1.Value.ToString();
            }
            else
            {
                //break was reached
                breakReached = true;
                countTime = 0;
                while(countTime != breakLength)
                {
                    //do the 2 min break
                }
                breakReached = false;
            }
            countTime++;
            countToFinish ++;
            if(countToFinish == finishTime)
            {//its done}
        }
