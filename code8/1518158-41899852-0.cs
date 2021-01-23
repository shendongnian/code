    private async Task HandleButtonTouched(object parameter)	
	{
		if (this.EnteredEmployeeCode.Count > 4)
			return;			
		
		string digit = parameter as string;
		this.EnteredEmployeeCode.Add(digit);
		this.UpdateEmployeeCodeDigits();
		if (this.EnteredEmployeeCode.Count == 4) {
			// let the view render on the platform
			await Task.Delay (1);
			this.SignIn ();
		}
	}
