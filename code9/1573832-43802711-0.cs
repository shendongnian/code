    public interface ICommand {
    	ICommandResult Execute();
    	ICommandResult Rollback();
    }
    
    public interface ICommandResult {
    	bool Success { get; set; }
    	object Data { get; set; }
    	Exception Error { get; set; }
    }
    
    public class CommandResult : ICommandResult { 
    	public bool Success { get; set; }
    	public object Data { get; set; }
    	public Exception Error { get; set; }
    }
    
    public class AddToDBCommand : ICommand {
    	private ICommandResult result;
    	private int newRecordId;
    	
    	public AddToDBCommand(<params_if_any>) {
    		result = new CommandResult();
    	}
    	
    	public ICommandResult Execute() {
    		try {
    			// insert record into db
    			result.Success = true;
    			result.Data = 10; // new record id
    		}
    		catch (Exception ex) {
    			result.Success = false;
    			result.Error = ex;
    		}
    		return result;
    	}
    	
    	public ICommandResult Rollback() {
    		try {
    			// delete record inserted by this command instance
    			// use ICommandResult.Data to get the 'record id' for deletion
    			Console.WriteLine("Rolling back insertion of record id: " + result.Data);
    			// set Success
    		}
    		catch(Exception ex) {
    			// set Success and Error
    			// I'm not sure what you want to do in such case
    		}
    		return result;
    	}
    }
