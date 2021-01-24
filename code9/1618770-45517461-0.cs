    public class TestModel
    {
        [FromRoute]
        public int Id { get; set; }
    
        [FromRoute]
        [Range(100, 999)]
        public int RootId { get; set; }
    
        [FromBody]
        [Required, MaxLength(200)]
        public string Name { get; set; }
    
        [FromBody]
        public string Description { get; set; }
    }
