	public class MyClass: IDataErrorInfo
	{
		public string SomeString1 { get; set; }
		public string AnotherString2 { get; set; }
		public bool IsValid
			=> string.IsNullOrWhiteSpace(Error);
		public string Error
			=> this["All"];
		public string this[string field]
		{
			get
			{
				string err = "";
				if (field == "All" || "SomeString1" == field)
				{
					if (SomeString1.Length > 15)
						err += "SomeString1 > 15";
					if (SomeString1.Length < 5)
						err += "SomeString1 < 5";
				}
				if (field == "All" || nameof(AnotherString2) == field )
				{
					err += StringLenthRule(AnotherString2, nameof(AnotherString2), 30, 20);
				}
				return err;
			}
		}
		private string StringLenthRule(string str, string prop,int max, int min)
		{
			string err = "";
			if (str.Length > max)
				err += $"{prop} > {max}\n";
			if (str.Length < min)
				err += $"{prop} < {min}\n";
			return err;
		}
	}
