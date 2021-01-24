    public class ViewModelBase : INotifyPropertyChanged
    {
        protected void SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (AreEqual(field, value))
            {
                return;
            }
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
