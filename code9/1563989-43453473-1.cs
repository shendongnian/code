    var query = db.people.AsQueryable();
    if(!string.IsNullOrEmpty(txtSurname.Text))
    {
        query = query.Where(p => p.Surname == txtSurname.Text);
    }
    if(!string.IsNullOrEmpty(txtFirstName.Text))
    {
        query = query.Where(p => p.FirstName == txtFirstName.Text);
    }
    peopleBindingSource.DataSource = query.ToList();
