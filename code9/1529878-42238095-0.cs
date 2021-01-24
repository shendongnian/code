    using System;
    namespace ConsoleApplication5
    {
        public interface IStream { }
        public interface IStreamWritable { void Write(IStream stream); }
        public interface IStreamReadable { void Read(IStream stream); }
        public interface IStreamReadableFactory { IStreamReadable Create(); }
        public class InstanceFactory : IStreamReadableFactory
        {
            public IStreamReadable Create() { throw new NotImplementedException(); }
        }
        public class StaticFactory : IStreamReadableFactory
        {
            public static IStreamReadable GetInstance() { throw new NotImplementedException(); }
            IStreamReadable IStreamReadableFactory.Create() { return GetInstance(); }
        }
        public static class Program
        {
            public static void Main()
            {
                IStream stream = null;
                var s1 = Read(new StaticFactory(), stream);
                var s2 = Read(new InstanceFactory(), stream);
            }
            static IStreamReadable Read(IStreamReadableFactory factory, IStream stream)
            {
                var t = factory.Create();
                t.Read(stream);
                return t;
            }
        }
    }
