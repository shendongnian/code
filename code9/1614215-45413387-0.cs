    class PersonFirstNameDto  {
        public string FirstName { get; set; }
    }
    var patients = allpatients.Select(p => new PersonFirstNameDto { FirstName = p.FIRSTNAME }).ToArray().Select(p => CreatePatient(p));
 
