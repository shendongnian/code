    public class ChangeViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Affaire> affaireListObservable;
        public ObservableCollection<Affaire> AffaireListObservable {
          get { return affaireListObservable; }
          set {
            affaireListObservable= value;
            if(PropertyChanged!=null) {
              PropertyChanged(this, new PropertyChangedEventArgs("AffaireListObservable"));
            }
          }
        }    
        public ChangeViewModel()
        {
            AffaireListObservable  = new ObservableCollection<Affaire>();
        }
        public void RemoveFromList()
        {
             foreach (Affaire aff in ListView1.SelectedItems)
             {
                  AffaireListObservable.Remove(aff);
             }
        }
    }
