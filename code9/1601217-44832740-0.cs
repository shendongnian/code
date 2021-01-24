    private List<MasterMenu> getDataMasterMenu3() {
	    var dtMasterMenuParent = new DataTable();
    	var dtMasterMenuChild = new DataTable();
    	var result = (from p in dtMasterMenuParent.AsEnumerable()
				 join c in dtMasterMenuChild.AsEnumerable() on p.Field<string>("ID") equals c.Field<string>("PARENT_ID") into cj
				 select new MasterMenu {
					 MasterMenuParent = new MasterMenuParent { Id = p.Field<string>("ID"), Name = p.Field<string>("NAME") },
					 MasterMenuChildOfParent = cj.Select(c => new MasterMenuChildOfParent {
						 Id = c.Field<string>("ID"),
						 Name = c.Field<string>("NAME"),
						 ParentId = c.Field<string>("PARENT_ID")
					 }).ToList()
				 }).ToList();
	    return result;
    }
