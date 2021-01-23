	using GalaSoft.MvvmLight;
	using GalaSoft.MvvmLight.Command;
	namespace MvvmLight1.ViewModel
	{
		/// <summary>
		/// This class contains properties that the main View can data bind to.
		/// <para>
		/// See http://www.mvvmlight.net
		/// </para>
		/// </summary>
		public class MainViewModel : ViewModelBase
		{
			public MainViewModel()
			{
			}
			public RelayCommand ButtonCommand
			{
				get { return new RelayCommand(() => { EnabledView = !EnabledView; }); }
			}
			private bool _environmentSource;
			public bool EnvironnementSource
			{
				get { return _environmentSource; }
				set { Set(ref _environmentSource, value); }
			}
			private string _idUtilisateur;
			public string IdUtilisateur
			{
				get { return _idUtilisateur; }
				set { Set(ref _idUtilisateur, value); }
			}
			private bool _enabledView;
			public bool EnabledView
			{
				get { return _enabledView; }
				set { Set(ref _enabledView, value); }
			}
		}
	}
