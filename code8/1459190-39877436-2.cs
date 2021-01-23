      private bool isConnected = false();
      private bool send(){
          if(!isConnected){
               connect();
          }
          //send
      }
      private bool connect(){
          if(!isConnected){
              //launch connection thread
          }
       }
      private delegate void onNewReceive(string message);
      public event onNewReceive onNewReceiveEvent;
      public void fireEvent(string message){
             onNewReceiveEvent.Invoke(message);
      }
           private void waitForData(object sender, DoWorkEventArgs e){
         //this is the backgroundworker
         while(true){
         receive();
         fireEvent(message);
         }
      }
