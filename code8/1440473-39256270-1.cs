    public class FirstEntity
    {
        public int Id { get; set; }
        [ForeignKey("FirstEntitySomeId")]
        public ICollection<SecondEntity> SecondEntityCollection { get; set; }
    }
