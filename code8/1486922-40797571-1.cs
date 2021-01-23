    abstract class Item : GameObject, ISellable
    { 
    }
    class GenericLoot : Item {
        public int BasePrice { get; }
    }
    class Slave : Person, ISellable {
        public int BasePrice { get; }
    }
