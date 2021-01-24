    namespace NS
    {       
        using System;
        using Bond.IO.Unsafe;
        using Bond.Protocols;
    
        internal static class Program
        {
            [Bond.Schema]
            interface IFoo
            {
                [Bond.Id(10)]
                string FooField { get; set; }
            }
        
            [Bond.Schema]
            class Bar
            {
                [Bond.Id(20)]
                public IFoo SomeFooInstance { get; set; }
            }
        
            class AlwaysUppercaseFoo : IFoo
            {
                private string fooField;
        
                public string FooField
                {
                    get
                    {
                        return fooField;
                    }
        
                    set
                    {
                        fooField = value.ToUpperInvariant();
                    }
                }
            }
        
            class IdentityFoo : IFoo
            {
                public string FooField { get; set; }
            }
        
            public static Expression NewAlwaysUppercaseFoo(Type type, Type schemaType, params Expression[] arguments)
            {
                if (schemaType == typeof(IFoo))
                {
                    return Expression.New(typeof(AlwaysUppercaseFoo));
                }
        
                // tell Bond we don't handle the requested type, so it should use it's default behavior
                return null;
            }
        
            public static Expression NewIdentityFoo(Type type, Type schemaType, params Expression[] arguments)
            {
                if (schemaType == typeof(IFoo))
                {
                    return Expression.New(typeof(IdentityFoo));
                }
        
                // tell Bond we don't handle the requested type, so it should use it's default behavior
                return null;
            }
        
            public static void Main(string[] args)
            {
                var src = new Bar() { SomeFooInstance = new IdentityFoo() { FooField = "Str" } };
        
                var output = new OutputBuffer();
                var writer = new CompactBinaryWriter<OutputBuffer>(output);
        
                Bond.Serialize.To(writer, src);
        
                {
                    var input = new InputBuffer(output.Data);
                    var deserializer = new Bond.Deserializer<CompactBinaryReader<InputBuffer>>(typeof(Bar), NewAlwaysUppercaseFoo);
                    var reader = new CompactBinaryReader<InputBuffer>(input);
                    var dst = deserializer.Deserialize<Bar>(reader);
                    Debug.Assert(dst.SomeFooInstance.FooField == "STR");
                }
        
                {
                    var input = new InputBuffer(output.Data);
                    var deserializer = new Bond.Deserializer<CompactBinaryReader<InputBuffer>>(typeof(Bar), NewIdentityFoo);
                    var reader = new CompactBinaryReader<InputBuffer>(input);
                    var dst = deserializer.Deserialize<Bar>(reader);
                    Debug.Assert(dst.SomeFooInstance.FooField == "Str");
                }
            }
        }
    }
