    public class MyViewModel {
        public ObservableCollection<MyGridObject> GridItems {get; set;}
    
        public void OnSomethingHappens(MyGridObject newObjectToAdd){
            GridItems.Add(newObjectToAdd);
        }
    }
    
    public class MyGridObject {
        public int ID {get; set;}
        public string Name {get; set;}
    }
