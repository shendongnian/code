    [Table("PERSON")]
    public class Person{
        [Column("ID"), PrimaryKey, NotNull]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name {get;set;}
        [Column("FIRST_NAME")]
        public string FirstName{ get;set;}
        public string DisplayName {get;set;}
        [Column("TOWN")]
        public string Town{get;set;}
        [Column("AGE")]
        public int Age {get;set;}
        public static Person Build(Person person, string displayName)
        {
            if (person != null)
            {
                person.DisplayName = displayName;    
            }
            return person;
        }
    }
