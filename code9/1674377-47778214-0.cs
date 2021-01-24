    public class Bag
    {
        public bool CanAddItem( Item item, float value, out Vector positionInBag )
        {
            // Do heavy calculation
            // Returns true if the item can be added into the bag
            // False otherwise
        }
        public void AddItem( Item item, Vector position )
        {
            // Add the item into the bag at the specified position
        }
    }
    public interface ICanBeDropped{
        public void Drop();
    }
    public class DropIntoBagHolder: ICanBeDropped{
        Item item;
        float amount;
        Bag bag;
        Vector positionInBag ;
        
        DropIntoBagHolder(...){ ... }
        
        public void Drop(){
            bag.AddItem( item, value maybe here?, positionInBag  ) ;
        }
    }
    public class Item
    {
        public ICanBeDropped PresentToBag( Bag bag, float value )
        {
            Vector positionInBag ;
            if( bag.CanAddItem( this, value, out positionInBag ) )
            {
                Console.WriteLine("I can be added " + positionInBag ) ;
                return new DropIntoBagHolder(....);
            }
            Console.WriteLine("I can't be added!" ) ;
            return null; // will cause exception
        }
    }
