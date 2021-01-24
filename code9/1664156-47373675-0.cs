    private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                Console.WriteLine("NotifyPropertyChanged Fired.");
            }
...
    public string Value {
                get => value.ToString();
                private set => this.value = Int32.Parse(value);
            }
