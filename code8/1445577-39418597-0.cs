    // on your DbContext type
    
    public override int SaveChanges(){
        DateTimeUtcHelper.SetDatesToUtc(this.ChangeTracker.Entries());
    	return base.SaveChanges();
    }
    
    class DateTimeUtcHelper{
    	internal static void SetDatesToUtc(IEnumerable<DbEntityEntry> changes) {
    		foreach (var dbEntry in changes.Where(x => ChangesToTrackList.Contains(new[] {EntityState.Added, EntityState.Modified}))){
    			foreach (var propertyName in dbEntry.CurrentValues.PropertyNames){
    				// using reflection add logic to determine if its a DateTime or nullable DateTime
    				// && if its kind = DateTimeKind.Local or Unspecified
    				// and then convert set the Utc value
    				// and write it back to the entry using dbEntry.CurrentValues[propertyName] = utcvalue;
    			}
    		}
    	}
    }
