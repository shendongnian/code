    Public class ViewModel
    {
    
        private Command viewCommand;
    
        public ViewModel()
        {
            viewCommand = new Command(CommandMethod);
        }
    
        public Command ViewModelCommand
        {
            get { return viewCommand }
            set { viewCommand = value}
        }
    
        private void CommandMethod()
        {
            //This method will hit if you modify enter/delete text in the     TextBox
        }
    
    }
