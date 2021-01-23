    private  void  button1_Click (object sender, EventArgs e)
       {
         DisplayMyGif(); //will display the gif on the UI thread, because click always comes from the UI
         Task.Factory.StartNew(()=>;
         {
             LoadMyData(); //should load the data asynchronously on a different Thread
         }
             );
    
       }
