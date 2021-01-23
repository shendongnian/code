    System.ComponentModel.BackGroundWorker textTime = new System.ComponentModel.BackGroundWorker();// use a reference Using System.ComponentModel; to avoid all this typing
    private void button1_Click(object sender, EventArgs e){//this event could be a button click, or whatever else you want to start the process
        textTime.DoWork+= beginTextTimer;
        textTime.RunWorkerAsync();
    }
    private void beginTextTimer(object sender, DoWorkEventArgs e){
         DateTime begin = DateTime.Parse(textbox_1.Text);//assumes you've already done validation
         int totalSeconds = 0;
         While(totalSeconds < 60){
            totalSeconds = DateTime.Now.Subtract(begin).TotalSeconds;//since you're pausing 1 second, you could just increment an integer here rather than doing a DateTime calculation - this works no matter what the pause is
             MethodInvoker mI = () => { 
                 textBox_1.Text = begin.AddSeconds(totalSeconds).ToString(); 
             };
             BeginInvoke(mI);//these two lines invoke back to the UI thread to change the textbox value    
             System.Threading.Thread.Sleep(1000);     
          }
    }
