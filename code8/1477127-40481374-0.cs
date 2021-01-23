    interface IAnimal
    {
        pubilc void Hunt();
    }
    interface IWeapon
    {
    }
    Animal : IAnimal
    {
        IWeapon _weapon;
        public void Animal(IWeapon weapon)
        {
           _weapon = weapon;
        }
        public void Hunt()
        {
            UseWeapon(_weapon);
        }
    
        protected abstract void UseWeapon(IWeapon weapon);
    }
