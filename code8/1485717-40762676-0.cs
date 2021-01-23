    public class ItemFactory
    {
        /*
         * Singleton pattern for factory, cause generally a factory only has one instance through out the app.
         */
        private static ItemFactory itemFactory;
        public static ItemFactory Instance
        {
            get
            {
                if (itemFactory == null)
                    itemFactory = new ItemFactory();
                return itemFactory;
            }
        }
    
        // method to create an instance of IItem, note the static modifier if you want to call it from base class, if
        // you use singleton, ignore static.
        public /*static*/ IItem CreateItem(string itemType)
        {
             Type type = Type.GetType(itemType);
             var temp = Activator.CreateInstance(type);
             return temp;
        }
    }
