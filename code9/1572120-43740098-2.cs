    class SomeOnesClassNotification : InotificationChanged  {
         
         public SomeOnesClassNotification(SomeOnesClass someOnesClass) {
              this.someOnesClass = someOnesClass; 
         }  
         private SomeOnesClass someOnesClass;
         
         private int count;
         public int Count {get {return count } 
                           set {count = value;  
                                NotifyCountChanged();
                               }
                          }
         NotifyCountChanged() {
             // Do stuff
         } 
    }
