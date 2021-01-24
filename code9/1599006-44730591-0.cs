       public DataLine(int a, System.Action action = null)
       {
         Qty = a;
         NotifyFromParent = action;
       }
    
       public System.Action NotifyFromParent;
