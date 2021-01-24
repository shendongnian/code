    // Changed to Generics. This makes the class easier to use than generics
    public class PoolOfObjects<T>
    {
        // Changed to private - you do not want this accessible from the outside
        // Changed the type to T so you do not have to cast.
        private T[] _objects;
    
        // Changed to prefix with _. 
        // Not all coding guidelines do this, but whatever you do be consistent.
        // Changed to states as there appears to be on per object.
        private bool?[] _states;
            
        // Using the standard Func<T> (function returning T)
        // instead of introducing a new delegate type
        private Func<T> _creator;
    
        // Changed to camelCase and Func<T> instead of custom delegate
        public PoolOfObjects(int objectsCount, Func<T> creator)
        {
            // Changed to remember the creator
            _creator = creator;
            // I left this an array, but consider changing to List<T>,
            // then the list can grow as needed. 
            _objects = new T[objectsCount];
            _states = new bool?[objectsCount];
    
            // removed initialization of objects
            // as it appears you do it when calling EjectObject
        }
    
        //Must return an exemplar by state of object when called 
        public Object EjectObject(bool? state)
        {
            // TODO:
            // You never assign any values to the _states array,
            // so it will always have the value null.
            // this means if your method is called with true or false,
            // it will FAIL!
            // I do not know what "states" is for so I can't suggest how to fix it.
    
            // If it is to track if an object is already in use I recommend getting
            // rid of it and change your _objects to be:
            //   private Queue<T> _objects
            // Then this method will check if there are any items in the _objects queue,
            // if there is dequeue one and return it. If not, create a new object
            // and return it.
            // You then need to create another method to put the items back in the queue
            // after use.
    
            int i;
            for (i = 0; i < _states.Length; i++)
                if (_states[i] == state)
                { //create object if null
                    if (_objects[i] == null)
                        // Changed to call your creator instead of assigning it.
                        _objects[i] = _creator();
                    break;
                }
            // TODO: Your program will crash with an unclear error here if no object
            // has a state matching the requested state.
            return _objects[i];
        }
    }
