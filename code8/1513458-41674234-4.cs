    public class ChosenItemCollection 
    {
        Dictionary<Type, Item> _fac = new Dictionary<Type, Item>();
    
        public T Add<T>(T item) where T : Item
        {
            if(!_fac.ContainsKey(typeof(T))
            {
                 _fac.Add(typeof(T), item);
            }
            else
            {
                _fac[typeof(T)] = item;
            }
        }
        public T GetChosenItem<T>() where T : Item
        {
            if(_fac.ContainsKey(typeof(T))
                return _fac[typeof(T)];
            return null;
        }
    }
