	using(EntryDBEntities mdbe = new EntryDBEntities())
	{
	  // PolicyList = await LoadPolicy(); // do not include this, it has nothing to do with adding a new entity based on the code you have shown
	  tblPolicy tbl = new tblPolicy(); //Creates a new policy entity
	  tbl.polID = 5; //Sets ID to 5
	  tbl.polName = "Ryder"; //Sets name
	  mdbe.tblPolicies.Add(tbl); //Adds to the dbcontext object
	  await mdbe.SaveChangesAsync(); //Saves changes
	}
	
