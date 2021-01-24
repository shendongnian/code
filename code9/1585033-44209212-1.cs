    var predicate = PredicateBuilder.True<Student>().And(i=>i.Id==id);
    if(!string.IsNullOrEmpty(searchText))
	{
	    if (firstNameColumnVisible) {
	       predicate = predicate.And(i=>i.FirstName.Contains(searchText));
		}
	    if (lastNameColumnVisible) {
	       predicate = predicate.And(i=>i.LastName.Contains(searchText));
		}
		// more columns here.
    }
 
