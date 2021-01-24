    public class Property {
    	public bool IsMortgaged {get;set;}
    }
    
    public class Player
    {
    	private List<Property> _properties = new List<Property>();
    	private double _cash = 0;
    	
    	public int AvailableMoney =>
    		_cash + _properties.Where(p => p.IsMortgaged).Select(p => p.MortgageValue).Sum();
    }
