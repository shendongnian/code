        public class MyViewModel
        { 
           private List<string> _items; 
           public void Load()
           {
               _items = new List<string>{ "Item1", "Item2" }
           }
           
         
           public int CountOfItems
           {
               get { return _items.Count; }
           }
        }
