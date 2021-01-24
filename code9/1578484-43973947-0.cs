    public class ContractDbContract
    {
    	public Contract Contract;
    	public DBContract DBContract;
    	
    	public int ID 
    	{
    		get
    		{
    			return Contract?.ID ?? DBContract.FromID;
    		}
    		
    	}
    }
    
    IEnumerable<Contract> ValidContracts = Application.GetContracts(//. . .
    IEnumerable<DBContracts> ExportedContracts = DBAdapter.GetRows(// . . .
    
    var validContracts2 = ValidContracts.Select(x => new ContractDbContract { Contract = x });
    var exportedContracts2 = ExportedContracts.Select(x => new ContractDbContract { DBContract = x });
