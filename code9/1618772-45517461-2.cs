    public class TestModel
        {
            [FromRoute]
            public int Id { get; set; }
    
            [FromRoute]
            [Range(100, 999)]
            public int RootId { get; set; }        
            
            [FromBody]
            public ChildModel OtherData { get; set; }        
        }
    
        
        public class ChildModel
        {            
            [Required, MaxLength(200)]
            public string Name { get; set; }
            
            public string Description { get; set; }
        }
