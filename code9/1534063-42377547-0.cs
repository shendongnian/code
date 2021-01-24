    private void SetCheckedValues()
    {
    	Action<Control.ControlCollection> func = null;
    	func = (controls) =>
    	{
    		foreach (Control control in controls)
    		{
    			if (control is CheckBox)
    			{
    				(control as CheckBox).Checked();
    				//set your other values to True creating a counter variable outside the foreach and 
    				//incrementing it inside here
    			}
    			else
    			{
    				func(control.Controls);
    			}
    		}
    	};
    	func(Controls);
    }
