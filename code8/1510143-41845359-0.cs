    public partial class Window1  {
    
        public Window1() {
          InitializeComponent();
          
          this._items.Add(new Item { Name = "one", DateTime = DateTime.Today });
          this._items.Add(new Item { Name = "two", DateTime = DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)) });
          this._items.Add(new Item { Name = "three", DateTime = DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0)) });
          this._items.Add(new Item { Name = "four", DateTime = DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)) });
          this._items.Add(new Item { Name = "five", DateTime = DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)) });
          this.DataContext = this;
        }
    
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
    
        public ObservableCollection<Item> Items => _items;
    
      }
    
    
      public abstract class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      public class Item : ViewModelBase {
        private string _name;
        private DateTime _dateTime;
    
        public string Name {
          get {
            return this._name;
          }
          set {
            if (value == this._name)
              return;
            this._name = value;
            this.OnPropertyChanged();
          }
        }
    
        public DateTime DateTime {
          get {
            return this._dateTime;
          }
          set {
            if (value.Equals(this._dateTime))
              return;
            this._dateTime = value;
            this.OnPropertyChanged();
          }
        }
    
      }
