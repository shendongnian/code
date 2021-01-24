    public class TheViewModel
        {
            private readonly ObservableCollection<ISelectable> listOfItems;
            public ObservableCollection<ISelectable> ListOfItems 
            {
                get { return listOfItems; }
            }
    
            public IEnumerable<ISelectable> GetSelectedElements
            {
                get { return listOfItems.Where(item=>item.CheckStatus); }
            }
            public TheViewModel(IList<ISelectable> dependencyItems)
            {
                listOfItems= new ObservableCollection<ISelectable>(dependencyItems);
            }
            //here is your list...
            private List<string> selectedNames = new List<string>();
            //use this...
            private void CollectNamesOfSelectedElements()
            {
               foreach(ISelectable item in GetSelectedElements)
               {
                 //you should override the ToString in your model if you want to do this...
                 selectedNames.Add(item.ToString());
               }
            }
        }
