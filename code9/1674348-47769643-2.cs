    public interface ISelectable
    {
        bool IsSelected { get; set; }
    }
    
    public class MyAwesomeClass : ISelectable
    {
        public bool IsSelected { get; set; }
    
        // Blah
    }
    
    private void RefreshSelection<T>(ObservableCollection<ISelectable> itemList, T selectedItem) 
        where T : class, ISelectable
    {
        foreach (var item in itemList)
        {
            item.IsSelected = selectedItem.Equals(item);
        }
    }
