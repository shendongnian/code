    [AddJsonTypename]
    public interface IAnimal
    {
        bool CanFly { get; }
    }
    [AddJsonTypename]
    public abstract class Animal : IAnimal
    {
        public bool CanFly { get; set; }
    }
