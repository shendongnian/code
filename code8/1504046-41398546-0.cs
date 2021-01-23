        private MvxCommand _clickCommand;
		public ICommand ClickCommand
		{
			get
			{
				_clickCommand = _clickCommand ?? new MvxCommand(Hit);
				return _clickCommand;
			}
		}
		private void Hit()
		{
			System.Diagnostics.Debug.WriteLine("Tapped Click Me");
			//System. .WriteLine ("Tapped Click Me");
		}
