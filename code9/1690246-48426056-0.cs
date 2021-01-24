    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var a = new AlwaysEqual();
                Assert.IsTrue(a == 1 && a == 2 && a == 3);
            }
    
            class AlwaysEqual
            {
                public static bool operator ==(AlwaysEqual c, int i) => true;
                public static bool operator !=(AlwaysEqual c, int i) => !(c == i);
                public override bool Equals(object o) => true;
                public override int GetHashCode() => true.GetHashCode();
            }
        }
    }
