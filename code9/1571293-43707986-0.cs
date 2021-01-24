    bool IsSmsSended = false;
    if(v >= 30 && !IsSmsSended) {
       do {
          var SmsMessenger= (CrossMessaging.Current.SmsMessenger);
          if(SmsMessenger.CanSendSmsInBackground){
             SmsMessenger.SendSmsInBackground("+000000","Test")
          }
       }
       while(((currentLocation.Speed * 3600) /1000) !=20);
       IsSmsSended = true;
    }else if(v < 30){
       IsSmsSended = false;
    }
