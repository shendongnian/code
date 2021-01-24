    public class Foo
    {
        //Same as the other one, but returns by ref C# 7
        public ref CoolClass GetSpecialItem_New(CoolClass[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i].Id > 100)
                {
                    return ref arr[i];
                }
            throw new Exception("Not found");
        }
    }
