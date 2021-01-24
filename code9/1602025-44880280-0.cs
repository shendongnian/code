    public Query Query { get; set; }
	#region Variabeles in Query you do not wish to rename in the partial views.
   
	public string Foo {
		get { return Query.Foo; }
		set { Query.Foo = value; }
	}
	#endregion 
