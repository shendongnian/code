    public List<object> GetPerson(int id)
    {
      var query = (from persons in entity.persons where persons.Id.Equals(id)
    
                  select new Person
                         {
                             PersonName = persons.PersonName,
                             PersonLastName = persons.PersonLastName,
                             PersonPatronymic = persons.PersonPatronymic,
                             SpecialSigns = new PersonSpecialSigns()
                             {
                                 BodyType = entity.persons_signs_body_type
    							                  .Where(c => c.PersonId == persons.Id)
    											  .Select(c => c.PersonBodyType),
                                 Hair = entity.persons_signs_hair
    							              .Where(c => c.PersonId == persons.Id)
    										  .Select(h => h.PersonHair)
                             }
                    });
    
        return query.ToList<object>();
    }
