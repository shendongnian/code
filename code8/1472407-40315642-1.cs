    using System;
    using System.IO;
    using System.Text;
    
    namespace StackOverflowSnippets
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(DoSomething<Int32>(new CreateSumOf(30, 12)));
                Console.WriteLine(DoSomething<Int32>(new CreateDifferenceOf(30, 12)));
                Console.WriteLine(DoSomething<String>(new ConcatenateStrings("Function Objects ", "are cool")));
                Console.ReadLine();
            }
    
            // This part can be considered the Framework and only has to be created once
            public static T DoSomething<T>(Function<T> f)
            {
                try
                {
                    using (Stream dbContext = new MemoryStream())
                    {
                        return f.ServiceImpl(dbContext);
                    }
                }
                catch (Exception)
                {
                    // HandleServiceLayerException();
                }
    
                throw new InvalidOperationException();
            }
            public abstract class Function<T>
            {
                public abstract T ServiceImpl(Stream /* DbContext */ dbContext);
            }
    
            // Then create one class for every ServiceFunction
            public class CreateSumOf : Function<Int32>
            {
                private Int32 _a;
                private Int32 _b;
    
                public CreateSumOf(Int32 a, Int32 b)
                {
                    _a = a;
                    _b = b;
                }
    
                public override Int32 ServiceImpl(Stream /*DbContext*/ dbContext)
                {
                    return (_a + _b);
                }
            }
            public class CreateDifferenceOf : Function<Int32>
            {
                private Int32 _a;
                private Int32 _b;
    
                public CreateDifferenceOf(Int32 a, Int32 b)
                {
                    _a = a;
                    _b = b;
                }
    
                public override Int32 ServiceImpl(Stream /*DbContext*/ dbContext)
                {
                    return (_a - _b);
                }
            }
            public class ConcatenateStrings : Function<String>
            {
                private String _a;
                private String _b;
    
                public ConcatenateStrings(String a, String b)
                {
                    _a = a;
                    _b = b;
                }
    
                public override String ServiceImpl(Stream /*DbContext*/ dbContext)
                {
                    StringBuilder b = new StringBuilder();
    
                    b.Append(_a); 
                    b.Append(_b);
    
                    return b.ToString();
                }
            }
        }
    }
