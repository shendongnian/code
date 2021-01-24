    private void OnFired(EventArgs e)
    {
    	object param = this.PassEventArgument ? e : this.CommandParameter;
    
    	if (!string.IsNullOrEmpty(this.CommandName))
    	{
    		if (this.Command == null) this.CreateRelativeBinding();
    	}
    
    	if (this.Command == null) throw new InvalidOperationException("No command available, Is Command properly set up?");
    
    	if (e == null && this.CommandParameter == null) throw new InvalidOperationException("You need a CommandParameter");
    
    	if (this.Command != null && this.Command.CanExecute(param))
    	{
    		this.Command.Execute(param);
    	}
    }
