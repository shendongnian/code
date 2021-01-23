    var loadDataTask = Task.Factory.StartNew(() =>
            {
                var persons = new List<PersonDepBureau>();
                using (PersonDBEntities db = new PersonDBEntities())
                {
                        persons = (from pers in db.Person
                                   join bu in db.Bureau on pers.Fk_IdBureau equals bu.IdBureau
                                   join dep in db.Departament on pers.Fk_IdDep equals dep.IdDep
                                   select new PersonDepBureau
                                   {
                                       IdPerson = pers.IdPerson,
                                       PersonName = pers.Name,
                                       Surname = pers.Surname,
                                       CurrentBureau = bu,
                                       CurrentDepartament = dep
                                   }).ToList();
                }
                return persons;
            }, CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
    loadDataTask.ContinueWith((t) =>
    {
        // you can check t.Exception for errors
 
        // Do UI logic here. (On UI thread)  
        foreach (var person in t.Result)
        {
              PersonData.Add(person);
        }
    }, TaskScheduler.FromCurrentSynchronizationContext());
