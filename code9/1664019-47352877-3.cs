    class Derived : Base
    {
         public override ObservableCollection<ItemBase> items
         {
             get { return new ObservableCollection<ItemBase>(SpecificItems); }
         }
    
         public ObservableCollection<ItemDerived> SpecificItems
         {
             get { //some stuff }
         }
    }
