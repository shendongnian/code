    public class ModifyUsersViewModel : INotifyPropertyChanged
    {
        private void Send_Data(int data)
        {
            IntAggregator.Transmit(data);
        }
    }
