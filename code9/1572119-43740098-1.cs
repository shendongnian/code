    class SomeOnesClassNotification : InotificationChanged  {
         
         public SomeOnesClassNotification(SomeOnesClass someOnesClass) {
              this.someOnesClass = someOnesClass; 
         }  
         private SomeOnesClass someOnesClass;
         public int Count {get {return someOnesClass.Count} 
                           set {someOnesClass.Count = value;  
                                NotifyCountChanged();
                               }
                          }
         NotifyCountChanged() {
             // Do stuff
         } 
    }
