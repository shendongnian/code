    private ElasticLowLevelClient client = new ElasticLowLevelClient();    
    private CreateIndexDescriptor descriptor = new CreateIndexDescriptor("myindex")
                  .Mappings(ms => ms
                  .Map<Person>("person", m => m.AutoMap())
                  .Map<Skill>("personskills", m => m.AutoMap().Parent("person"))
              );        
    
    public void CreatePerson(Person person)
    {
        client.CreateIndex(descriptor); //I am creating it here but one can create it in the class where we will create ElasticClient
        var parentResponse = client.Index(person, i => i.Index("myindex").Type("person").Id(person.PersonId));
        foreach (var skill in person.Skills)
        {
           var skillResponse = client.Index(skill, i => i.Index("myindex").Type("personskills").Parent(person.PersonId.ToString()).Id(skill.SkillId)); //here I am getting error
        }
    }
