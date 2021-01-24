    public partial class YourClass
    {
        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }
    }
