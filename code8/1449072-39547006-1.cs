     private ICommand loadedCommand = new DelegateCommand<string>(text => 
            {
                MessageBox.Show(text);
            });
            public ICommand LoadedCommand { get { return loadedCommand; } }
