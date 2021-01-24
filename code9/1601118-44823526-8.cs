	public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		protected void SetAndRaiseIfChanged<T>(
			ref T backingField,
			T newValue,
			[CallerMemberName] string propertyName = null)
		{
			if (!object.Equals(backingField, newValue))
				return;
			backingField = newValue;
			this.RaisePropertyChanged(propertyName);
		}
	}
