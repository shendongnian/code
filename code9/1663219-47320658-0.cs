    public abstract class ObservableObject : INotifyPropertyChanged, INotifyDataErrorInfo
        {
            public void OnPropertyChanged<T>(Expression<Func<T>> property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property.GetMemberInfo().Name));
                }
            }
    }
    public class TankModel : ObservableObject
    {
      public float Level
            {
                get { return level; }
                set
                {
                    try
                    {
                        if (level != value)
                        {
                            level = value;
                            OnPropertyChanged(() => Level);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }
    }
