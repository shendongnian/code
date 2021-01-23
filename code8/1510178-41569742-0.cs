	using System;
	[Flags]
	public enum Value
	{
		None = 0,
		Go = 1,
		Stand = 2,
		Jump = 4,
		Run = 8
	}
						
	public class Program
	{
		public static void Main()
		{	
			var value1 = CreateValue(true, false, true, false);
			var value2 = CreateValue(false, true, true, true);
			
		    Console.WriteLine(value1); //Go, Jump
		    Console.WriteLine(value2); //Stand, Jump, Run
		}
		
		public static Value CreateValue(bool go, bool stand, bool jump, bool run)
		{
			var value = Value.None;
			
			if(go)
				value |= Value.Go;
			
			if(stand)
				value |= Value.Stand;
			
			if(jump)
				value |= Value.Jump;
			
			if(run)
				value |= Value.Run;
			
			return value;
		}
	}
