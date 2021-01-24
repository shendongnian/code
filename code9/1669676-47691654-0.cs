    public interface IFruits
    {
        Fruit GetItem();
        void ProcessItem(Fruit fruit);
        void Check();
    }
    // I changed the name of your IFruitsBase, because it's the same thing as IFruits
    // No need to have 2 differents names to name the same thing    
    public interface IFruits<T> : IFruits where T : Fruit
    {
        T GetItem();
        void ProcessItem(T fruit);
        void Check();
    }
