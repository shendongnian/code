     private void button1_Click(object sender, EventArgs e)
            {            
                Timer MyTimer = new Timer();
                MyTimer.Interval = 4000; 
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();
               
            }
    
            private void MyTimer_Tick(object sender, EventArgs e)
            {
                button1.BackColor = Color.Black;
    
            }
