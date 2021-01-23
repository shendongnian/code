    var personData = entity.persons.FirstOrDefault(i = i.Id == id);
    if(personData != null)
    {
        var person = new Person
        {
            PersonName = personData.PersonName,
            PersonLastName = personData.PersonLastName,
            PersonPatronymic = personData.PersonPatronymic,
            SpecialSigns = new PersonSpecialSigns()
            {
                BodyType = entity.persons_signs_body_type
                                 .Where(i => i.PersonId == personData.Id) 
                                 .Select(i => i.PersonBodyType),
                Hair = entity.persons_signs_hair
                             .Where(i => i.PersonId == personData.Id)
                             .Select(i => i.PersonHair)
             }
       };
       //continue with the code
    }
    
