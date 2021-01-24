    // Break generics by checking the type explicitly. Requires ugly casting
    // and intermediate boxing, though it's possible that with some run-time
    // use of Expressions, you could cache a delegate that would handle the
    // conversion without the boxing. It'd still be ugly though.
    class Class1<T>
    {
        public Class1(T t) { }
        public static implicit operator Class1<T>(bool value)
        {
            if (typeof(T) == typeof(string))
            {
                return (Class1<T>)(object)(Class1OfString)value;
            }
            throw new InvalidOperationException("Invalid type T");
        }
    }
    // Subclass the generic, and declare the conversion there. Of course, then
    // to use the conversion, you have to reference this type explicitly. Ugly.
    class Class1OfString : Class1<string>
    {
        public Class1OfString(string text) : base(text) { }
        public static implicit operator Class1OfString(bool value)
        {
            return new Class1OfString(value.ToString());
        }
    }
    class A
    {
        public static void M()
        {
            // These all compile and execute fine
            Class1OfString c1 = true;
            Class1<string> c2 = (Class1OfString)true;
            Class1<string> c3 = true;
        }
    }
