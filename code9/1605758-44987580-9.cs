    class ViewModel : INotifyPropertyChanged
      {
        public ViewModel()
        {         
        }
    
        public ICommand LongRunningCommand => new RelayCommand(
          async (param) => await this.LongRunningTaskAsync().ConfigureAwait(false), (param) => true);
    
        public async Task LongRunningTaskAsync()
        {
          await Task.Run(
            () =>
            {
              for (int i = 0; i < 3; i++)
              {
                Thread.Sleep(5000);
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
