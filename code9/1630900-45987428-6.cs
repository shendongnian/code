      class ExampleViewModel : INotifyPropertyChanged {
        private string _customerLastName;
        private string _customerName;
    
        public event CancelButtonClicked CancelButtonClicked;
    
        public string CustomerName {
          get { return this._customerName; }
          set {
            this._customerName = value;
            this.OnPropertyChanged();
          }
        }
    
        public string CustomerLastName {
          get { return this._customerLastName; }
          set {
            this._customerLastName = value;
            this.OnPropertyChanged();
          }
        }
    
        public ExampleViewModel(string customerName, string customerLastName) {
          this.CustomerName = customerName;
          this.CustomerLastName = customerLastName;
        }
    
        private void OnAbortButtonClick(object sender, EventArgs args) {
          
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    
      internal delegate void CancelButtonClicked(object sender);
    
      public class SomeOtherClass {
        private ExampleViewModel _viewModel;
    
        public SomeOtherClass() {
          this._viewModel = new ExampleViewModel("foo", "bar");
          this._viewModel.CancelButtonClicked += ViewModelOnCancelButtonClicked;
        }
    
        private void ViewModelOnCancelButtonClicked(object sender) {
          ExampleViewModel vm = sender as ExampleViewModel;
          vm.CustomerName = "foo"; //set the initial values again
          vm.CustomerLastName = "bar";
        }
      }
