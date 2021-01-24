    IQueryable<Student> studentQuery = context.Students;
    if (ColonieFilterCheckBox.Checked) {
	    studentQuery = studentQuery.Where(x => x.Colonie);
    }
    if (NatationFilterCheckBox.Checked) {
	    studentQuery = studentQuery.Where(x => x.Nataion);
    }
    if (ExcursionFilterCheckBox.Checked) {
	    studentQuery = studentQuery.Where(x => x.Excursion);
    }
    var _filteredStudents = await studentQuery.ToListAsync().ConfigureAwait(false);
