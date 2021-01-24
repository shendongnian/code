    internal class ChronicleDatePicker : DatePicker
    {
        Command cmd = new Command();
        public ICommand IncreaseDay
        {
            get
            {
                return cmd;
            }
        }
    }
    class Command :ICommand
    {
        internal DateTime? selectedDate = null;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            var picker = ((ChronicleDatePicker)parameter);
            picker.SelectedDate = picker.SelectedDate.Value.AddDays(1);
        }
    }
