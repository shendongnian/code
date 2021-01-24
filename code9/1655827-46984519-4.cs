    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	class parameter
    	{
    		public string Name;
    		public string Value;
    		public string Type;
    
    		public string FormattedValue
    		{
    			get
    			{
    				if (Type == "Boolean")
    				{
    					if (Value == "True")
    						return "1";
    					else
    						return "0";
    				}
    				else if (Type == "Int32")
    				{
    					return Value;
    				}
    				else
    					throw new Exception("Unsupported type - " + Type);
    			}
    			
    		}
    
    		public override string ToString()
    		{
    			return string.Format("{0} - {1} - {2} - {3}", Name, Value, Type, FormattedValue);
    
    		}
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    
    
    		var sb = new StringBuilder();
    		var data = Clipboard.GetText(TextDataFormat.UnicodeText);
    		var lines = data.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    		var parameters = GetParmeters(lines);
    		parameters.Reverse();
    
    		foreach (var item in lines)
    		{
    			if (item.Trim().Length == 0)
    				continue;
    			if (item.TrimStart().StartsWith("--"))
    				continue;
    
    			var SQLLine = item;
    			foreach (var p in parameters)
    			{
    				SQLLine = SQLLine.Replace("@" + p.Name, p.FormattedValue);
    			}
    			sb.AppendLine(SQLLine);
    		}
    
    		Clipboard.SetText(sb.ToString());
    	}
    
    	private static List<parameter> GetParmeters(string[] lines)
    	{
    		var parameters = new List<parameter>();
    		foreach (var item in lines)
    		{
    			var trimed = item.Trim();
    			if (trimed.StartsWith("-- p__linq__") == false)
    				continue;
    
    			var colonInd = trimed.IndexOf(':');
    			if (colonInd == -1)
    				continue;
    
    			var paramName = trimed.Substring(3, colonInd - 3);
    			var valueStart = colonInd + 3;
    			var valueEnd = trimed.IndexOf('\'', valueStart);
    			if (valueEnd == -1)
    				continue;
    
    			var value = trimed.Substring(valueStart, valueEnd - valueStart);
    
    			var typeStart = trimed.IndexOf("(Type = ");
    			if (typeStart == -1)
    				continue;
    			typeStart += 8;
    
    			var typeEnd = trimed.IndexOf(',', typeStart);
    			if (typeEnd == -1)
    				typeEnd = trimed.IndexOf(')', typeStart);
    			if (typeEnd == -1)
    				continue;
    
    			var type = trimed.Substring(typeStart, typeEnd - typeStart);
    
    			var param = new parameter();
    			param.Name = paramName;
    			param.Value = value;
    			param.Type = type;
    
    			parameters.Add(param);
    		}
    
    		return parameters;
    	}
    }
