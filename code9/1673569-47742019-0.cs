    interface IInterface
    {
        ReturnType this[int index] { get; }
    }
    class Foo: IInterface
    {
        ReturnType IInterface.this[int index]
        {
            get { return ... }
        }
    }
