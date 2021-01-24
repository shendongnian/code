    public void CreatePerson(Person person)
            {
     client.Map<Skill>(m => m
                                     .Parent("person").Index("myindex")); //this will put the default mapping of default index
    var parentResponse = client.Index(person, i => i.Index("myindex").Type("person").Id(person.PersonId));
        foreach (var skill in person.Skills)
        {
           var skillResponse = client.Index(skill, i => i.Index("myindex").Type("skill").Parent(person.PersonId.ToString()).Id(skill.SkillId)); //here I am getting error
        }
    }
