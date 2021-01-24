	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public ViewModelLocator
		{
			this.FirstModel= new UserControl1Model
			{
				Message = "Hello";
			}
			
			this.SecondModel = new UserControl2Model
			{
				Message = "Test";
			}
		}
		
		private UserControl1Model firstModel
		public UserControl1Model FirstModel
		{
			get 
			{
				return this.firstModel;
			}
			
			set
			{
				this.firstModel= value;
				OnPropertyChanged("FirstModel");
			}
		}
		
		// Same for the UserControl2Model
		
		// implementation of the INotifyPropertyChanged
	}
	
