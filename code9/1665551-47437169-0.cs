    public PersonDynamicInfo(){ 
        Id(x => x.Id); 
        Table("PersonDynamicInfo"); 
        Map(x => x.Key);
        Map(x => x.Value);
        References(x => x.Person, "PersonId").Cascade.All(); 
    } 
