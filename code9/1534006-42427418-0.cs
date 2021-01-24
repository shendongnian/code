    public interface IBaseEntity<Key>
    {
        [Key]
        Key Id { get; set; }
    }
