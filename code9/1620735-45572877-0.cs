		public class AsyncProperty<T> : INotifyPropertyChanged
		{
			public async Task UpdateAsync(Task<T> updateAction)
			{
				LastException = null;
				IsUpdating = true;
				try
				{
					Value = await updateAction.ConfigureAwait(false);
				}
				catch (Exception e)
				{
					LastException = e;
					Value = default(T);
				}
				IsUpdating = false;
			}
			private T _value;
			public T Value
			{
				get { return _value; }
				set
				{
					if (Equals(value, _value)) return;
					_value = value;
					OnPropertyChanged();
				}
			}
			private bool _isUpdating;
			public bool IsUpdating
			{
				get { return _isUpdating; }
				set
				{
					if (value == _isUpdating) return;
					_isUpdating = value;
					OnPropertyChanged();
				}
			}
			private Exception _lastException;
			public Exception LastException
			{
				get { return _lastException; }
				set
				{
					if (Equals(value, _lastException)) return;
					_lastException = value;
					OnPropertyChanged();
				}
			}
			public event PropertyChangedEventHandler PropertyChanged;
			[NotifyPropertyChangedInvocator]
			protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
