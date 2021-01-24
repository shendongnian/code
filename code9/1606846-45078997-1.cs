    [NotifyPropertyChanged]
    public class MyWindowViewModel {
    
        /// Anything bound to this refreshes just fine as expected
        [AggregateAllChanges] // <-- when the collection changes to cause notification
        public ObservableCollection<SomeType> Documents { get; } => new ObservableCollection<SomeType>();
    
       [Command]
       public ICommand AddDocumentCommand { get; set; }
       public void ExecuteAddDocument () { Documents.Add(new SomeType()); }
    
       [Command]
       public ICommand CloseDocumentCommand { get; set; }
       public bool CanExecuteCloseDocument => Documents.Any(); 
       public void ExecuteCloseDocument () { Documents.Remove(Documents.Last()); }        
    }
