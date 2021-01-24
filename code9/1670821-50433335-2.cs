    using System.ComponentModel;
    using System.Runtime.CompilerServices;
	// Use this as base class for all your "view model" classes.
    // And possibly for your (domain) model classes.
	// E.g.:  "public class MyLoginViewModel : HasNotifyPropertyChanged".
	// OR     "public class MyLoginModel : HasNotifyPropertyChanged".
    // Give it whatever name you want, for ViewModels I suggest "ViewModelBase".
	public class HasNotifyPropertyChanged : INotifyPropertyChanged
	{
		// --- This is pattern to use to implement each property. ---
		//     This works for any property type: int, Color, etc.
		//     What's different from a standard c# property, is the "SetProperty" call.
		//     You will often write an IValueConverter (elsewhere) to use in XAML to convert from string to your property type.
		//     Comment out this example property if you don't need it.
		/// <summary>
		/// Set to "true" at end of your initialization.
		/// Then can use Property Trigger on Ready value=true in XAML to do something when your instance is ready for use.
		/// For example, load something from web, then trigger to update UI.
		/// </summary>
		private bool _ready;
		public bool Ready
		{
			get => _ready;
			set => SetProperty(ref _ready, value);
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property == null || !property.Equals(value))
            {
                property = value;
                RaisePropertyChanged(propertyName);
            }
        }
		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
