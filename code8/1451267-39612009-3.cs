      public MyObject FindBestMatching(int Prop1Value, int Prop2Value, int Prop3Value) {
        MyObject result1 = null;
        MyObject result2 = null;
    
        foreach (MyObject item in myList) {
          if (item.Prop1 == Prop1Value) {
            result1 = item;
    
            if (item.Prop2 == Prop2Value) {
              result2 = item;
            
              if (item.Prop3 == Prop3Value) 
                return item; 
            }
          }  
        }
    
        return result2 ?? result1; 
      }
