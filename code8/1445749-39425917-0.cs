    public static class ControlExtensions
    {
    	public static void FixTextBoxBindings(this Control control)
    	{
    		if (control is TextBox)
    		{
    			foreach (Binding binding in control.DataBindings)
    				if (binding.NullValue == null) binding.NullValue = "";
    		}
    		foreach (Control child in control.Controls)
    			child.FixTextBoxBindings();
    	}
    }
