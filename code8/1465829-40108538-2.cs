    class ArrayWrapper<T>
    {
        private readonly T[] _arr;
        private readonly int _w, _h;
        public ArrayWrapper(T[] arr, int w, int h)
        {
            if(arr == null)
                throw new ArgumentNullException("arr");
            if(arr.Length != w*h)
                throw new ArgumentException("Invalid array length", "arr");
            _arr = arr;
            _w = w;
            _h = h;
        }
        public T this[int i, int j]
        {
            get { return _arr[i*_w + j]; }
        }
    }
---------
    var arr = new[] {
        0,  1,  2,  3, 
        4,  5,  6,  7, 
        8,  9,  10, 11, 
        12, 13, 14, 15 };
    var wrapper = new ArrayWrapper<int>(arr, 4, 4);
    Console.WriteLine(wrapper[1, 1]); // prints 5
