    public class Configuration {
       public class Values {  
          public int SomeSetting1 { get; }
          public int SomeSetting2 { get; }
       }
       private Values currentValues;
       public Values CurrentValues {
          get {
             return currentValues;
          }
       }
       private void OnDataChanged() {
          Values newValues = new Values(getValuesFromDatabase());
          currentValues = newValues;
       }
    }
