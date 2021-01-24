    namespace NS
    {
        using System;
        using Bond.IO.Unsafe;
        using Bond.Protocols;
    
        internal static class Program
        {
            enum FooKind
            {
                Unknown = 0,
                AlwaysUppercase = 1,
                Identity = 2,
            }
    
            // intentionally a class to work around https://github.com/Microsoft/bond/issues/801 but simulate an interface somewhat
            [Bond.Schema]
            class IFoo
            {
                [Bond.Id(0)]
                public virtual string FooField { get; set; }
            }
    
            [Bond.Schema]
            class Bar
            {
                [Bond.Id(0)]
                public Bond.IBonded<IFoo> SomeFooInstance { get; set; }
    
                [Bond.Id(1)]
                public FooKind Kind { get; set; }
            }
    
            [Bond.Schema]
            class AlwaysUppercaseFoo : IFoo
            {
                private string fooField;
    
                public override string FooField
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
    
                [Bond.Id(0)]
                public string JustAlwaysUppercaseFooField { get; set; }
            }
    
            [Bond.Schema]
            class IdentityFoo : IFoo
            {
                [Bond.Id(42)]
                public string JustIdentityFooField { get; set; }
            }
    
            static void RoundTripAndPrint(Bar src)
            {
                var output = new OutputBuffer();
                var writer = new CompactBinaryWriter<OutputBuffer>(output);
    
                Bond.Serialize.To(writer, src);
    
                var input = new InputBuffer(output.Data);
                var reader = new CompactBinaryReader<InputBuffer>(input);
                var dst = Bond.Deserialize<Bar>.From(reader);
    
                switch (dst.Kind)
                {
                    case FooKind.Identity:
                        {
                            var fooId = dst.SomeFooInstance.Deserialize<IdentityFoo>();
                            Console.WriteLine($"IdFoo: \"{fooId.FooField}\", \"{fooId.JustIdentityFooField}\"");
                        }
                        break;
    
                    case FooKind.AlwaysUppercase:
                        {
                            var fooUc = dst.SomeFooInstance.Deserialize<AlwaysUppercaseFoo>();
                            Console.WriteLine($"UcFoo: \"{fooUc.FooField}\", \"{fooUc.JustAlwaysUppercaseFooField}\"");
                        }
                        break;
    
                    default:
                        Console.WriteLine($"Unknown Kind: {dst.Kind}");
                        break;
                }
            }
    
            public static void Main(string[] args)
            {
                var o = new OutputBuffer();
                var w = new CompactBinaryWriter<OutputBuffer>(o);
                Bond.Serialize.To(w, new IdentityFoo() { FooField = "Str", JustIdentityFooField = "id" });
    
                var src_id = new Bar()
                {
                    SomeFooInstance = new Bond.Bonded<IdentityFoo>(new IdentityFoo() { FooField = "Str", JustIdentityFooField = "id" }),
                    Kind = FooKind.Identity
                };
    
                var src_uc = new Bar()
                {
                    SomeFooInstance = new Bond.Bonded<AlwaysUppercaseFoo>(new AlwaysUppercaseFoo() { FooField = "Str", JustAlwaysUppercaseFooField = "I LIKE TO YELL!" }),
                    Kind = FooKind.AlwaysUppercase
                };
    
                RoundTripAndPrint(src_id);
                RoundTripAndPrint(src_uc);
            }
        }
    }
