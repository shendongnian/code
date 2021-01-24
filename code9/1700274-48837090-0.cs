    public class MainViewModel
    {
        private IDialog dialog;
        private ICommand showCommand;
        public MainViewModel() : this(null)
        {
        }
        public MainViewModel(IDialog dialog)
        {
            this.dialog = dialog;
            this.showCommand = new ShowCommand(this.ShowCommandHandler);
        }
        private void ShowCommandHandler(object sender, EventArgs e)
        {
            this.dialog.Show();
        }
        public ICommand ShowCommand { get { return this.showCommand; } }
    }
