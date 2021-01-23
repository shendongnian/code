    public void OnMyButtonClick(Office.IRibbonControl control)
    {
    	try
    	{
    		object context = control.Context;
    		if (context == null) return false;
    		if (context is Outlook.AttachmentSelection)
    		{
    			Outlook.AttachmentSelection selectedAttachments = context as Outlook.AttachmentSelection;
    			SelectedAttachment = attachment[1];
    			OutlookCommon._fName = SelectedAttachment.FileName;
    			// etc...
    		}
    		Marshal.ReleaseComObject(context); context = null;
    		}
    	catch (Exception ex)
    	{
    		Console.WriteLine("attachmentButton_Click  " + ex.ToString());
    	}
    }
