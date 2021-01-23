       private void btnSync_Click(object sender, EventArgs e)
       {
          DateTime localDateTime = DateTime.Now;
          //localDateTime.Hour=13; // cannot be changed, so create a new DateTime
          DateTime newDT = new DateTime(localDateTime.year, localDateTime.month, localDateTime.day,
             13, localDateTime.minute, localDateTime.second, localDateTime.millisecond);
          SetSystemDateTime(newDT
          // set datetime a second time to avoid issues when crossing DST intervals
          System.Threading.Thread.Sleep(500);
          SetSystemDateTime(newDT); 
       }
