    public interface IHasId<T> where T: struct
    {
            T ID { get; set; }
    }
    
    public class PESSOAS: IHasId<int>
    {
            [Key]
            public int ID { get; set; }
    }
