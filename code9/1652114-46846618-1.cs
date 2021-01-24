	public class Model : System.ComponentModel.INotifyPropertyChanged {
		public void OnPropertyChanged(string name) {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
