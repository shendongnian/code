    public class CustomDataGridView : DataGridView
    {
    	bool SuppressDataGridViewKeyProcessing => ContainsFocus && !Focused &&
    		(EditingControl == null || !EditingControl.ContainsFocus);
    
    	protected override bool ProcessDataGridViewKey(KeyEventArgs e)
    	{
    		if (SuppressDataGridViewKeyProcessing) return false;
    		return base.ProcessDataGridViewKey(e);
    	}
    
    	protected override bool ProcessDialogKey(Keys keyData)
    	{
    		if (SuppressDataGridViewKeyProcessing)
    		{
    			if (Parent != null) return DefaultProcessDialogKey(Parent, keyData);
    			return false;
    		}
    		return base.ProcessDialogKey(keyData);
    	}
    
    	static readonly Func<Control, Keys, bool> DefaultProcessDialogKey =
    		(Func<Control, Keys, bool>)Delegate.CreateDelegate(typeof(Func<Control, Keys, bool>),
    		typeof(Control).GetMethod(nameof(ProcessDialogKey), BindingFlags.NonPublic | BindingFlags.Instance));
    }
