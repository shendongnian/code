      class ExampleViewModel : INotifyPropertyChanged {
        private string _customerLastName;
        private string _customerName;
        private string _initialCustomerName;
        private string _initialCustomerLastName;
    
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
          this._initialCustomerName = customerName;
          this._initialCustomerLastName = customerLastName;
        }
    
        //example event handler for your abort button
        private void OnAbortButtonClick(object sender, EventArgs args) {
          this.CustomerName = this._initialCustomerName; //set the initial name
          this.CustomerLastName = this._initialCustomerLastName; //set the initial lastName
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
