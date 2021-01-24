	public async Task<Parms> ReadParmsAsync ()
	{
		var db = GetConnectionAsync ();
		var query = db.Table<Parms> ().Where (p => p.Id == 1);
		return await query.FirstOrDefaultAsync ();
	}
