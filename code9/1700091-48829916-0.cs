    public interface IAnimal
    {
        void Breathe();
    }
    public interface ILegged
    {
        void Stand();
    }
    public interface IFlyingAnimal : IAnimal
    {
        void Fly();
    }
    public interface ILeggedAnimal : IAnimal, ILegged
    {
    }
    public interface IBird : IFlyingAnimal, ILeggedAnimal
    {
    }
    public class Eagle : IBird
    {
        public void Breathe()
        {
            throw new NotImplementedException();
        }
        public void Stand()
        {
            throw new NotImplementedException();
        }
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
