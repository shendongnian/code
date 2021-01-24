    public class Configuration {
       private object sync = new object();
       private int someSetting1;
       public int SomeSetting1 {
          get {
             lock (sync) {
                return someSetting1;
             }
          }
       }
       private decimal someSetting2;
       public decimal SomeSetting2 {
          get {
             lock (sync) {
                return someSetting2;
             }
          }
       }
    
       private void OnDataChanged() {
          lock (sync) {
             someSetting1 = loadFromDatabase();
             someSetting2 = loadFromDatabase();
          }
       }
    }
