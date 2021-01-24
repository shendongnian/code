    using Mvvm;
	namespace Test_Tool
	{
		public class MainPageViewModel : BindableBase
		{
			private bool _isDirect = false;
			public bool IsDirect
			{
				get { return _isDirect; }
				set { SetProperty(ref _isDirect, value); }
			}
		}
	}
