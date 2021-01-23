    public List<object> GetPerson(int id)
    {
        var query = entity.persons.First(x=> x.Id == id).Select(x=> new Person
                    {
                         PersonName = x.PersonName,
                         PersonLastName = x.PersonLastName,
                         PersonPatronymic = x.PersonPatronymic,
                         SpecialSigns = new PersonSpecialSigns                         
                         {
                             BodyType = entity.persons_signs_body_type
                                          .Where(y => y.PersonId == x.Id)
                                          .Select(y => y.PersonBodyType),
                             Hair = entity.persons_signs_hair
                                          .Where(y => y.PersonId == x.Id)
                                          .Select(y => y.PersonHair)
                         }
                     });
        return query.ToList<object>();
    }
