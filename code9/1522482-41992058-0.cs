    class ImmutableDictionary<T>
    {
        private readonly Dictionary<int, T> _dict = new Dictionary<int, T>();
        private readonly Queue<int> _holes = new Queue<int>();
        private int _nextInt = 0; //what is next integer to assign, I'm starting at 0, but can be int.MinValue
        private int AssignKey()
        {
            //if we have a hole, use that as the next key. Otherwise use the largest value we haven't assigned yet, and then increment that value by 1
            return _holes.Count != 0 ? _holes.Dequeue() : _nextInt++;
        }
    
        public void Add(T input)
        {
            _dict.Add(AssignKey(), input);
        }
    
        public void Remove(int key)
        {
            if (_dict.Remove(key)) //if a remove is successful, we should add a hole
            //you can extend the logic here to not add a hole if you are removing something equal to _nextInt - 1.
                _holes.Enqueue(key);
        }
    }
