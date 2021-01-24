    public class CustomDataGridView : DataGridView
    {
    	bool SuppressDataGridViewKeyProcessing => ContainsFocus && !Focused && 
    		(EditingControl == null || !EditingControl.ContainsFocus);
    
    	protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    	{
    		if (SuppressDataGridViewKeyProcessing) return false;
    		return base.ProcessDataGridViewKey(e);
    	}
    }
