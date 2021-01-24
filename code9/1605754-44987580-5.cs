    class ViewModel : INotifyPropertyChanged
      {
        public ViewModel()
        {         
        }
    
        public ICommand LongRunningCommand => new RelayCommand(
          async (param) => await this.LongRunningTask(), (param) => true);
    
        public async Task LongRunningTask()
        {
          await Task.Run(
            () =>
            {
              for (int i = 0; i < 3; i++)
              {
                Task.Delay(5000).Wait();
                this.Text = $"Iteration #{i + 1}  completed";
              }
            });
        }
    
        private string text;   
        public string Text
        {
          get { return this.text; }
          set 
          { 
            this.text = value; 
            OnPropertyChanged();
          }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
