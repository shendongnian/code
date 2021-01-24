    // Where Stacking
    if (!string.IsNullOrEmpty(FieldA.Text))
    {// OR
        result = query.Where(item => item.Something.Contains(FieldA.Text));
    }
    if (!string.IsNullOrEmpty(FieldB.Text))
    {// AND
        result = result.Where(item => item.SomethingElse.Contains(FieldB.Text));
    }
	// Predicate
	if (CheckBox1.Checked || CheckBox2.Checked || CheckBox3.Checked))
	{//Here your initialise your predicate to false because you are going to do OR
		var predicate = PredicateBuilder.False<SearchItem>();
		if(CheckBox1.Checked) predicate = predicate.Or(item => item.Foo == 1);
		if(CheckBox2.Checked) predicate = predicate.Or(item => item.Foo == 2);
		if(CheckBox3.Checked) predicate = predicate.Or(item => item.Foo == 3);
		result = result.Where(predicate);
	}
	
