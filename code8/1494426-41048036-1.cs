    static void Main()
        {
            PublicClass P = new PublicClass();
            System.Collections.IList list = P.PublicMethod() as System.Collections.IList;
            object internalObject = list[0];
            FieldInfo fi = internalObject.GetType().GetField("b", BindingFlags.NonPublic | BindingFlags.Instance);
            byte b = (byte)fi.GetValue(internalObject);
            Console.WriteLine(b);
        }
