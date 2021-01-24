        /// <summary>
        /// This class wrapps any enum and make values changeable.
        /// </summary>
        /// <typeparam name="T">Struct to be wrapped</typeparam>
        public class ChangeableEnum<T> where T : struct, IConvertible
        {
            // This dict contains all values of enum
            IDictionary<T, int> _dict;
            /// <summary>
            /// Constructor intializes with the given enum (as generic-class-type)
            /// </summary>
            public ChangeableEnum()
            {
                _dict = new Dictionary<T, int>();
                // iterate over each value and get value
                foreach (T obj in Enum.GetValues(typeof(T)))
                    _dict.Add(obj, Convert.ToInt32(obj));
            }
            /// <summary>
            /// Get or set a value of enum.
            /// </summary>
            /// <param name="obj">Enum-type to get or set</param>
            /// <returns>Value of given enum-type.</returns>
            public int this[T obj]
            {
                get { return _dict[obj]; }
                set { _dict[obj] = value; }
            }
        }
