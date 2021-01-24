    public class ChangeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged=delegate {};
        private void NotifyPropertyChanged([CallerMemberName] String 
                                                      propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new 
                     PropertyChangedEventArgs(propertyName));
            }
        }
        ObservableCollection<Affaire> affaireListObservable;
        public ObservableCollection<Affaire> AffaireListObservable {
          get { return affaireListObservable; }
          set {
            affaireListObservable= value;
            if(PropertyChanged!=null) {
              NotifyPropertyChanged();
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
