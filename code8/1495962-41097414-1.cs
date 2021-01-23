    public class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {
    	public DataGridViewCalendarCell()
    	: base()
    	{
    		// Use the short date format.
    		this.Style.Format = "d";
    	}
    
    	public override void InitializeEditingControl(int rowIndex, object
    		initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    	{
    		// Set the value of the editing control to the current cell value.
    		base.InitializeEditingControl(rowIndex, initialFormattedValue,
    			dataGridViewCellStyle);
    		DataGridViewCalendarEditingControl ctl =
    			DataGridView.EditingControl as DataGridViewCalendarEditingControl;
    		// Use the default row value when Value property is null.
    		if (this.Value != null || !String.IsNullOrEmpty(initialFormattedValue.ToString()))
    		{
    			DateTime parsedDate;
    			bool IsDate = DateTime.TryParseExact(this.Value.ToString(), "d/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
    			if (IsDate)
    			{
    				ctl.Value = parsedDate;
    			}
    		}
    	}
    
    	public override Type EditType
    	{
    		get
    		{
    			// Return the type of the editing control that DataGridViewCalendarCell uses.
    			return typeof(DataGridViewCalendarEditingControl);
    		}
    	}
    
    	public override Type ValueType
    	{
    		get
    		{
    			// Return the type of the value that DataGridViewCalendarCell contains.
    
    			return typeof(DateTime);
    		}
    	}
    
    	public override object DefaultNewRowValue
    	{
    		get
    		{
    			// Use the current date and time as the default value.
    			return null;
    		}
    	}
    }
