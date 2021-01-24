    public class InfoCommand : ICommand
    {
        Member _member;
        public InfoCommand(Member member)
        {
            _member = member;
            _member.PropertyChanged += _member_PropertyChanged;
        }
        private void _member_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
                RaiseCanExecuteChanged();
        }
        private void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            if (_member.Name.Length > 0)
                return true;
            else
                return false;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            MessageBox.Show("I am " + _member.Name);
        }
    }
