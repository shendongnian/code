	public class ViewModel
	{
		public ICommand DeleteProjectCommand => new DelegateCommand(DeleteProject);
		
		private void DeleteProject(object parameter)
		{
		}
	}
