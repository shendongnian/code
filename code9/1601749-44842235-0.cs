    public class MyViewModel
        {
            public ObservableCollection<ItemViewModel> Items { get; set; }
    
            public ICommand SaveCommand { get; }
    
            public MyViewModel()
            {
                SaveCommand = new RelayCommand(OnSaveCommand);
                Items = new ObservableCollection<ItemViewModel>();
                Items.Add(new ItemViewModel{Name = "test1", Value = "test1"});
                Items.Add(new ItemViewModel{Name = "test2", Value = "test2"});
            }
    
            private void OnSaveCommand()
            {
                var message = Items.Aggregate(new StringBuilder(),
                    (builder, item) => builder.AppendLine($"{item.Name} {item.Value}"));
                message.AppendLine("Will be save");
    
    
                MessageBox.Show(message.ToString());
            }
        }
    
        public class ItemViewModel : NotifiableObject
        {
            private string _value;
            private string _name;
    
            public string Name
            {
                get => _name;
                set
                {
                    OnPropertyChanged();
                    _name = value;
                }
            }
    
            public string Value
            {
                get => _value;
                set
                {
                    OnPropertyChanged();
                    _value = value;
                }
            }
        }
    
        public class NotifiableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
