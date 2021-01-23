    public void sendNotification(int typeNum){
       if (typeNum <= 100)
       {  
          if (!Emum.IsDefined(typeof(module1NotificationTypes), typeNum))
          { 
             throw new ArgumentException();
          }
          //DO Processing
       }
       else 
       {
          if (!Emum.IsDefined(typeof(module2NotificationTypes), typeNum))
          { 
             throw new ArgumentException();
          }
          //DO Processing
       }
    }
