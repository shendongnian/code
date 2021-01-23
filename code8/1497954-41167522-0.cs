	void Main()
	{
		List<Hospital> oldList;
		List<Hospital> newList;
	
		using (var oldDb = new oldBAEntity())
		{
			oldList=  oldDb.Hospitals.ToList();			
		}
		using (var newDb = new NewDbContextEntities())
		{
			newList = newDb.Hospitals.ToList();
        }
			
		var joined = oldList.Join(newList, 
			old => old.Id, 
			oldItem => oldItem.Id, 
			(old, newItem) => new 
				{ 
					NewId = newItem.Id, 
					NewName = newItem.Name, 
					// do whatever you have to do instead of this
					OldSettlementId = old.SettlementId
			});
			
		using (var newDb = new NewDbContextEntities())
		{
			// perform your update using the joined here
		}
	}
	
	class Hospital
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string SettlementId  { get; set; }
	}
