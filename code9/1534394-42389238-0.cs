     internal class Database
     {
    	private bool _isDisposed;
    	private OpenSaveReportWizardForm _wizardForm;
     
      public Database()
      {
          _wizardForm = new  OpenSaveReportWizardForm(m_Opening,m_ConnectionProperties,m_ColumnProperties))
          _wizardForm.saveEvent += (sender, e) => HandleSaveMethod( );
         
      }
    
    public void HandleSaveMethod()
      {
       // do something
      }
      
      public void Dispose()
      {
    	if(_isDisposed)
    		return;
    		
    	_isDisposed = true;
      
    	_wizardForm.saveEvent -= HandleSaveMethod;
    	_wizardForm.Dispose();
      }
