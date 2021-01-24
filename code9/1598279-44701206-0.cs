    public class Quarter {
    
    	private readonly DateTime _startDate;
    	private readonly DateTime _endDate;
    
    	public Quarter(DateTime startDate, DateTime endDate) {
    		_startDate = startDate;
    		_endDate = endDate;
    	}
    
    	public DateTime StartDate => _startDate;
    	public DateTime EndDate => _endDate;
    }
