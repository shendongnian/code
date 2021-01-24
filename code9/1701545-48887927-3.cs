     private ICommand _showCommand;
        public ICommand ShowCommand => _showCommand ?? (_showCommand = new Command(ButtonClickAction));
        public void ButtonClickAction()
        {
           //Your action
        }
