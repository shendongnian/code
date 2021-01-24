    public class Box<T>
    {
        public T Value {get;set;}
        public Box<T>(T item) {Value = item;}
    }
    Box<byte>[] array = {new Box<byte>(0), new Box<byte>(1), new Box<byte>(2), new Box<byte>(3), new Box<byte>(4)};
    Box<byte>[] subarray = array.Skip(2).Take(3).ToArray();
    subarray[0].Value = 8;
    Console.WriteLine("array[2] = " + array[2].Value);
    //you'll see "8" instead of "2" now
