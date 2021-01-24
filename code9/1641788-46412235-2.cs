	public interface IIndividual
	{
		string Name { get; set; }
		string Number { get; set; }
		string Address { get; set; }
	}
	
	public interface IGuardian : IIndividual
	{
        // Only things specific to Guardians should be here
        // If there is nothing specific to Guardians, 
        // dont have a IGuardian interface at all
		string WorkPhone { get; set; }
	}
	public class Student : IIndividual
	{
        //Guardian should be a property of a Student
		public IGuardian Guardian { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
    }
	public class Guardian: IGuardian
	{		
		public string Name { get; set; }
		public string Number { get; set; }
		public string Address { get; set; }
		public string WorkPhone { get; set; }
    }
