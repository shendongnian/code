    public class ModifyUsersViewModel : INotifyPropertyChanged
    {
        private void change_tab(int data)
        {
            IntAggregator.Transmit(data);
        }
    }
