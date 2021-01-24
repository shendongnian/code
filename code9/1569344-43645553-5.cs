    public class TheViewModel
        {
            private readonly ObservableCollection<CheckBoxListModel> listOfItems;
            public ObservableCollection<CheckBoxListModel> ListOfItems 
            {
                get { return listOfItems; }
            }
            public TheViewModel(IList<CheckBoxListModel> dependencyItems)
            {
                //by the way, if i were you i should make an interface for CheckBoxListModel too.
                listOfItems= new ObservableCollection<CheckBoxListModel>(dependencyItems);
            }
        }
