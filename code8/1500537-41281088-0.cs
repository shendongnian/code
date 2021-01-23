        public class ContactDTO
        {
            public int? Id { get; set; }    
            [ForeignKey("Person")]
            public int? PersonId { get; set; }
        } 
