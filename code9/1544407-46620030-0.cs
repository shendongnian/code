    public interface ISchool {
		string[] ParentNumber
		{
			get;
			set;
		}
	}
	
	public class School : ISchool
	{
		string[] parentNumber;
		public string [] ParentNumber
		{
			get
			{
				return this.parentNumber;
			}
			set
			{
				if (value[0] == "MS")
					throw new NotImplementedException();
				else
					this.parentNumber = value;
			}
		}
	}
    class Program
	{
		static void Main(string[] args)
		{
			ISchool tt = new School();
			
			tt.ParentNumber = new string [] {"MSX", "TY", "KU"};
			foreach (var pst in tt.ParentNumber)
			{
				Console.WriteLine(pst);
			}
			
			
			Console.Read();
		}
	}
