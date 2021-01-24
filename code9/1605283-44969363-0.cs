    public class ServiceBase
        {
    	
    	   protected void ExecuteOperation(Action codetoExecute)
            {            					
    			try
                {				
    				 using (TransactionScope scope = new TransactionScope())
    				{					
    					codetoExecute.Invoke();				
    					scope.Complete();                
    				}			                
                }
    			catch (TransactionAbortedException ex)
    			{
    				// handle exception
    			}
    			catch (ApplicationException ex)
    			{
    				// handle exception
    			}            
            }
    	}
