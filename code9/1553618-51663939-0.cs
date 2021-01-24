    public class CustomDataGridView : DataGridView
    {
    	protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    	{
    		if (ContainsFocus && !Focused && EditingControl == null) return false;
    		return base.ProcessDataGridViewKey(e);
    	}
    }
