	public class JsonConverter
	{
		LinkedList<JsonField> jsonlinking = new LinkedList<JsonField>();
		public void Add(JsonField jsonfield)
		{
			LinkedListNode<JsonField> jsonelement = jsonlinking.Last;
			if (jsonelement != null)
			{
				jsonelement.Value.SpecialChar = ",";
			}
			jsonlinking.AddLast(jsonfield);
		}
		public string GetJsonFormat()
		{
			jsonformat = string.Empty;
			jsonformat += "{" + Environment.NewLine;
			foreach (var item in jsonlinking)
			{
				ReadJson(item);
			}
			jsonformat += Environment.NewLine + "}" + Environment.NewLine;
			return jsonformat;
		}
		public static void MapField(JsonField primary, JsonField relative)
		{
			primary.Next = relative;
		}
		public static void MapField(Queue<JsonField> linksource)
		{
			JsonField primary = null;
			JsonField relative = null;
			foreach (var item in linksource)
			{
				if (primary == null)
				{
					primary = item;
				}
				else if (relative == null)
				{
					relative = null;
				}
				else
				{
					JsonConverter.MapField(primary, relative);
					primary = null;
					relative = null;
				}
			}
		}
		private string jsonformat = string.Empty;
		private void ReadJson(JsonField field)
		{
			if (field != null)
			{
				jsonformat += @"""";
				jsonformat += field.Name;
				jsonformat += @"""";
				if (field.isContainer)
				{
					jsonformat += @":{" + Environment.NewLine;
					int count = field.ChildNodes.Count();
					if (count > 0)
					{
						foreach (var item in field.ChildNodes)
						{
							ReadJson(item);	
						}
					}
					jsonformat = (jsonformat.Substring(jsonformat.Length - 1, 1) == ",") ? jsonformat.Substring(0, jsonformat.Length - 1) : jsonformat;
					jsonformat += @"}" + field.SpecialChar + Environment.NewLine;
				}
				else
				{
					jsonformat += @":";
					jsonformat += field.GetValues();
				}
			}
		}
	}
	public class JsonField
	{
		private int Size = 1;
		private int CurrentIndex = 0;
		public string Name { get; set; }
		private string[] _value;
		public string[] Value { get { return _value; } private set { _value = value; } }
		public bool isContainer{get;set;}
		public JsonField()
		{
			this.Value = new string[this.Size];
		}
		private Queue<JsonField> _next = new Queue<JsonField>();
		public JsonField Next { 
			set 
			{
				if (this._next.Count>0)
				{
					foreach (var item in this._next)
					{
						item.SpecialChar = ",";
					}
					
				}
				this._next.Enqueue(value); 
			} 
		}
		public IEnumerable<JsonField> ChildNodes { get { return this._next; } }
		public JsonField(int valuesize)
		{
			this.Size = valuesize;
			this.Value = new string[this.Size];
		}
		public JsonField(bool iscontainer)
		{
			this.isContainer = iscontainer;
		}
		public void AddValue(string value)
		{
			if (CurrentIndex >= this.Value.Length)
			{
				throw new ArgumentException("Index Out of Range over Value Array");
				return;
			}
			this.Value[CurrentIndex] = value;
			CurrentIndex++;
		}
		public void ClearValue()
		{
			this.Value = null;
			this.Value = new string[this.Size];
		}
		public string GetValues()
		{
			if (this.Value.Length == 1)
			{
				return @"""" + this.Value[0] + @"""";
			}
			string returns=string.Empty;
			for (int index = 0; index < this.Value.Length; index++)
			{
				returns += @"""" + this.Value[index] + @"""";
				if ((index +1) < this.Value.Length)
				{
					returns += ",";
				}
			}
			return "[" + returns+ "]";
		}
		public string SpecialChar { get; set; }
	}
