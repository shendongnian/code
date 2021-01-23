    public sealed class ElementsOrNull<T> where T: class
    {
        readonly IList<T> array;
        public ElementsOrNull(IList<T> array)
        {
            this.array = array;
        }
        public T this[int index]
        {
            get
            {
                if (index < array.Count)
                    return array[index];
                return null;
            }
        }
    }
