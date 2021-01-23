	public class PacmanAgent
	{
		private string ArgumentBase = "-q -p PacmanQAgent -x 2000 -n 2010 -l smallGrid -a ";
		[Range(0, 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
		public double Epsilon { get; set; }
		[Range(0, 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
		public double Alpha { get; set; }
		[Range(0, 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
		public double Gamma { get; set; }
		public PacmanAgent(int epsilon, int alpha , int gamma )   
		{
			 Epsilon = epsilon;
			 Alpha = alpha; 
			 Gamma = gamma; 
		}   
		public string GetArgument()
		{
			string argument = string.Format("{0} epsilon={1}, alpha={2}, gamma={3}", ArgumentBase, Epsilon, Alpha, Gamma)
			return argument
		}
		public void IncrementEpsilon(double i = 0.01)
		{
			Epsilon += i;
		}
	    public void IncrementAlpha(double i = 0.01)
		{
			Alpha += i;
		}
		public void IncrementGamma(double i = 0.01)
		{
			Gamma += i;
		}
	}
