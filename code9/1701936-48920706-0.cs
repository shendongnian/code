    class Person
    {
         public int PersonId {get; set}
         public string Name {get; set;}
         public string StudentNumber {get; set;}
         public string FieldWithUniqueConstraint {get; set}
         public string EmployeeNumber {get; set;}
         public virtual ICollection<PersonRole> PersonRoles {get; set}  
    }
    
    class PersonRole
    {
         public in PersonRoleId {get; set;}
         public ICollection<Person> People {get; set;}
         public string RoleName {get; set;}
    }
