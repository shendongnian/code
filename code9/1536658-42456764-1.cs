    class Robot
    {
    	private List<Positie> visitedPositions = new List<Positie>();
    	public void PrintPositions () {
    		foreach (var pos in visitedPositions) {
    			Console.WriteLine (pos.X + " " + pos.Y);
    		}
    	}
    	...
    
    	public virtual void Stap()
    	{
    		switch (Richting)
		    {
			    case Richting.Boven:    Positie.Y++;
			    break;
			    case Richting.Onder:    Positie.Y--;
			    break;
			    case Richting.Links:    Positie.X--;
			    break;
			    case Richting.Rechts:   Positie.X++;
			    break;
		    }
    		visitedPositions.Add (new Positie (Positie.X, Positie.Y));
    
    	}
    	public virtual void Stap(int aantalStappen)
    	{
    		...
    		visitedPositions.Add (new Positie (Positie.X, Positie.Y));
    	}
    
    }
    
    class Program 
    {
    	static void Main(string[] args)
    	{
    		...
    		Robot robot1;
    		...
    
    		robot1.Stap ();
    		robot1.PrintPositions ();
    	}
    }
