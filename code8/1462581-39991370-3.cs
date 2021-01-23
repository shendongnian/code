    public sealed class Foo : ViewModelBase
	{
		private Employee employee = new Employee();
		
		private string Name
		{
			get { return employee.Name; }
			set 
			{ 
				employee.Name = value; 
				RaisePropertyChangedEvent("Name"); 
				// This will let the View know that the Name property has updated
			}
		}
		
		// Add more properties
		
		// Bind the button Command event to NewName
		public ICommand NewName
		{
			get { return new DelegateCommand(ChangeName)}
		}
		
		private void ChangeName()
		{
			// do something
			this.Name = "NEW NAME"; 
			// The view will automatically update since the Name setter raises the property changed event
		}
	}
