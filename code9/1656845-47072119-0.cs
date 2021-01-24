	public class CustomCommand : ICommand
	{
        private Action<object> onPictureClick;
        public CustomCommand(Action<object> onPictureClick)
        {
            this.onPictureClick = onPictureClick;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            // Nothing happening here :(
        }
    }
	
