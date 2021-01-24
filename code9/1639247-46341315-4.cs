	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class showColumnAttribute : System.Attribute
	{
		///<summary>Optional display format for column</summary>
		public string Format;
		///<summary>Optional Header string for column<para>Defaults to propety name</para></summary>
		public string Title;
		///<summary>Optional column edit flag - defaults to false</summary>
		public bool ReadOnly;
		///<summary>Optional column width</summary>
		public int Width;
		///<summary>
		///Marks public properties that are to be displayed in columns
		///</summary>
		public showColumnAttribute()
		{
			Format = String.Empty;
			Title = String.Empty;
			ReadOnly = false;
			Width = 0;
		}
	}
