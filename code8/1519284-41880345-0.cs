       private void btnSync_Click(object sender, EventArgs e)
       {
          DateTime localDateTime = DateTime.Now;
          localDateTime.Hour=13;
          SetSystemDateTime(localDateTime);
          // set datetime a second time to avoid issues when crossing DST intervals
          System.Threading.Thread.Sleep(500);
          SetSystemDateTime(localDateTime); 
       }
