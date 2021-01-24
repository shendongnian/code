	public class DetailRecord
	{
		private readonly string _originalText;
		
		static private Dictionary<string, Func<string,string>> _map = new Dictionary<string, Func<string,string>>
		{
			{ "ContractNo", s => s.Substring( 1  ,10 )        },
			{ "BankNum",    s => s.Substring( 15 , 8 )        },
			{ "ShortName",  s => s.Substring( 35 ,10 ).Trim() }
		};
		
		public DetailRecord(string originalText)
		{
			_originalText = originalText;
		}
		
		public string this[string key]
		{
			get
			{
				return _map[key](_originalText);
			}
		}
		public string BankNum
		{
			get { return this["BankNum"]; }
		}
		public string ContractNo
		{
			get { return this["ContractNo"]; }
		}
		public string ShortName
		{
			get { return this["ShortName"]; }
		}
		
		public bool IsValid
		{
			get
			{
				int dummy;
				
				if (!int.TryParse(this.ContractNo, out dummy)) return false;
				if (!Regex.IsMatch(this.BankNum, @"[A-Z]\d\d\s\s\d\d\d")) return false;
					
				return true;
			}
		}
	}
