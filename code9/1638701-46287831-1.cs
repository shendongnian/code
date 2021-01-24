    public class PlayCommand : ICommand
    {
        ...
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _viewModel.Play();
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
