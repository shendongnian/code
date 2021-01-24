    	public class darco
		{
		public string darktype { set; get; } = String.Empty;
		public darco( string mydarktype)
			{
			darktype = mydarktype;
			}
		public override string ToString()
			{
			return "For dark chocolate, you have selected: " + darkType;
			}
		}
