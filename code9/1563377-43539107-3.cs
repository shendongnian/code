    using System.ComponentModel;
    namespace PTR.PTRLib.Common {
	public class Notifiable : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string propertyName) {
			// take a copy to prevent thread issues
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	 }
    }
