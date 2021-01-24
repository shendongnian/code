		#region Virtualisation
		static readonly Virtualiser Virtual = new Virtualiser(typeof(UserRecord));
		[XmlIgnore] // just in case!
		public static int ColumnCount { get { return Virtual.ColumnCount; } }
		public static VirtualColumnInfo ColumnInfo(int column)
		{
			return Virtual.ColumnInfo(column);
		}
		public Object GetItem(int column)
		{
			return Virtual.GetItem(column, this);
		}
		/*
		** The supplied item should be a string - it is up to this method to supply a valid value to the property
		** setter (this is the simplest place to determine what this is and how it can be derived from a string).
		*/
		public void SetItem(int column, Object item)
		{
			String v = item as String;
			int t = 0;
			if (v == null)
				return;
			switch (Virtual.GetColumnPropertyName(column))
			{
				case "DisplayNumber":
					if (!int.TryParse(v, out t))
						t = 0;
					item = t;
					break;
			}
			try
			{
				Virtual.SetItem(column, this, item);
			}
			catch { }
		}
		#endregion
 
