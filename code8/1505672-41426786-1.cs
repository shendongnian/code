    void timer1_Tick(object sender, EventArgs e) 
    { 
       //Based on singleton instance,
       if (NetworkAvailabilty.Instance.IsNetworkAvailable)
       {
          GetDataFromHttp();
       }
       else
       {
          //No Internet connection
       }
    }
