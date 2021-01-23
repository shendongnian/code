	public class LibrarySettings : INotifyPropertyChanged
	{
		public LibrarySettings()
		{
			IsOperationOneEnabled = false;;
			OperationOneRate = 0;
			IsOperationTwoEnabled = false;
			OperationTwoRate = 0;
		}
		public bool IsOperationOneEnabled { get;set; }
		public double OperationOneRate { get; set; }
		public bool IsOperationTwoEnabled { get;set; }
		public double OperationTwoRate { get; set;}
		
		#region INPC Impl
		#region
	}
