    interface IAnimal
    {
    }
    class Dog : IAnimal
    {
    }
    class Cat : IAnimal
    {
    }
    interface IVeterinarian
    {
        void Heal(IAnimal animal);
    }
    abstract class BaseVeterinarian<T> : IVeterinarian
        where T : IAnimal
    {
        public void Heal(IAnimal animal)
        {
            Heal((T)animal);
        }
        protected abstract void Heal(T animal);
    }
    class DogVeterinarian : BaseVeterinarian<Dog>
    {
        protected override void Heal(Dog animal)
        {
        }
    }
    class CatVeterinarian : BaseVeterinarian<Cat>
    {
        protected override void Heal(Cat animal)
        {
        }
    }
