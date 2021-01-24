		private Command command;
		public ICommand GetDataCommand
		{
			get
			{
				getDataCommand = command ?? new Command(DoCommand, CanExecute);
				return command;
			}
		}
