    public void Timer_tick ( object sender eventargs e)
    {
        PushData();  // with time interval =100    
    }
    public void PushData()
    {
       Form2 fr = new Form2();
       frm.Closed += fr_Closed;
       // function to reading .csv file
       if ( checkData(name) == "OK") 
       {
         //update data to SQL Server    
       }
       else 
       {
          timer1.Stop();
          fr.Show();  // User need to click OK button to hide Form2 and come back Form1
          this.Refresh();
       }
    }
    void fr_Closed(object sender, EventArgs e)
    {
         timer1.Start();
    }
