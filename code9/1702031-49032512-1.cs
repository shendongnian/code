            public void AddButton(string param)
        {
            Button btn = new Button();
            switch (param)
            {
                case "Files":
                    btn.Content = "Do Files";
                    btn.CommandParameter = "Files";
                    btn.Name = "Files";
                    break;
              //More items here
            }
            btn.Command = ExecuteButtonCommand; //The ICommand name. I made this harder than it needed to be!
            Buttons.Add(btn);
        }
            public RelayCommand _executeButtonCommand;
        public ICommand ExecuteButtonCommand
        {
            get
            {
                if (_executeButtonCommand == null)
                    _executeButtonCommand = new RelayCommand(param => this.ButtonCommands(param));
                return _executeButtonCommand;
            }
        }
