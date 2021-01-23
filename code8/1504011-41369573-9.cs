    public sealed class RangeOperationManager
    {
        // A map of ranges to operations
        private Dictionary<Tuple<int, int>, Func<Tuple<int, int>, int, bool>> RangeToOperationMap { get; }
            = new Dictionary<Tuple<int, int>, Func<Tuple<int, int>, int, bool>>();
        // Encapsulates how to add new range to operation mappings. 
        // It's like a façade method.
        public void AddOperation(int min, int max, Func<Tuple<int, int>, int, bool> processor)
            => RangeToOperationMap[Tuple.Create(min, max)] = processor;
        public bool Operate(int input)
        {
            // We try to get an operation associated with a range based on the input
            var foundPair = RangeToOperationMap
                .SingleOrDefault
                (
                    // Let's see if we find a range for the given input!
                    pair => input >= pair.Key.Item1
                            && input <= pair.Key.Item2
                );
            // If this "if" evaluates true, it would mean that no range could be found
            //
            // NOTE: We need to check if retrieved pair isn't key-value pair default
            // value because it's an structure (value type).  
            if (!foundPair.Equals(default(KeyValuePair<Tuple<int, int>, Func<Tuple<int, int>, int, bool>>)))
            {
                // If some could be found, then we proceed to call the associated
                // delegate giving the range and input as arguments!
                return foundPair.Value(foundPair.Key, input);
            }
            else
            {
                throw new InvalidOperationException("Input couldn't match any of configured ranges");
            }
        }
    }
