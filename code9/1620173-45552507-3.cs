    public class Owner //or player
    {
    	private double _cash;
    	
    	public double AvailableCash
    	{
    		get {return _cash;}
    	}
    
        public void MortgageProperty(Property item)
        {
            if(item.SetMortgaged())
            {
                _cash += item.Value / 2
            }
            else
            {
                //Throw an error or something else to let the user know it failed
            }
        }
    }
