			#region Display columns
		[showColumn(ReadOnly = true, Width = 100, Title = "Identification")]
		public String DisplayIdent
		{
			get
			{
				return ident;
			}
			set
			{
				ident = value;
			}
		}
		[showColumn(Width = 70, Title = "Number on Roll")]
		public int DisplayNumber
		{
			get
			{
				return number;
			}
			set
			{
				number = value;
			}
		}
		[showColumn(Width = -100, Title = "Name")]
		public string DisplayName
		{
			get
			{
				return name == String.Empty ? "??" : name;
			}
			set
			{
				name = value;
			}
		}
		#endregion
