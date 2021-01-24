    public class CustomDateTimePicker : DateTimePicker
    {
    	public CustomDateTimePicker()
    	{
    		Format = DateTimePickerFormat.Custom;
    		SetValueCore(null);
    	}
    
    	new public DateTime? Value
    	{
    		get { return Checked ? base.Value : (DateTime?)null; }
    		set
    		{
    			if (Value != value)
    				SetValueCore(value);
    		}
    	}
    
    	private void SetValueCore(DateTime? value)
    	{
    		if (value == null)
    			Checked = false;
    		else
    			base.Value = value.Value;
    		UpdateCustomFormat();
    	}
    
    	protected override void OnValueChanged(EventArgs eventargs)
    	{
    		UpdateCustomFormat();
    		base.OnValueChanged(eventargs);
    	}
    
    	private void UpdateCustomFormat()
    	{
    		CustomFormat = Value != null ? "dd-MMM-yyyy" : " ";
    	}
    }
