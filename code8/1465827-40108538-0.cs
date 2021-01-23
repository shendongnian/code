    class ArrayWrapper
    {
        private readonly int[] _arr;
        private readonly int _w, _h;
        public ArrayWrapper(int[] arr, int width, int h)
        {
            _arr = arr;
            _w = width;
            _h = h;
        }
        public int this[int i, int j]
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
    var wrapper = new ArrayWrapper(arr, 4, 4);
    Console.WriteLine(wrapper[1, 1]); // prints 5
