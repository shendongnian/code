     private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 100;
            }
    int timerCounter=0;
            private void timer1_Tick(object sender, EventArgs e)
            {
                timerCounter += 100;
    
                if (timerCounter == 100)
                {
                    var proc = Process.Start("chrome.exe", "google.com"); //open chrome tab.
                }
    
                if (timerCounter == 5000) //5000 = 5  minutes , like waiting time for 5 mins  to execute the function on this page .
                {
                    proc.Kill(); //remove tab
                    timerCounter = 0;
                    timer1.Stop();
                }
                
            }
     private void button2_Click(object sender, EventArgs e)
            {
                timer1.Start();
            }
