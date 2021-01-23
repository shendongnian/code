    [Table("Pokemon")]
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [InverseProperty("Pokemon")]
        public ICollection<Encounter> Encounters { get; set; }
    
    }
    
    [Table("Enconters")]
    public class Encounter
    {
        public int Id { get; set; }
    
        public int PokemonId { get; set; }
    
        [ForeignKey("PokemonId")]
        public Pokemon Pokemon { get; set; }
    
    }
