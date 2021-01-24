    using Xunit;
    using NSubstitute;
    using System;
    public interface IDbOperations {
        void TestMethod(MyClass2 myClass2);
    }
    public class MyClass2 {
        public String MyString { get; set; }
    }
    public class MyClass {
        private IDbOperations Ops { get; }
        public MyClass(IDbOperations ops) { Ops = ops; }
        public void MyMethod(object arg1, object arg2, string test) {
            Ops.TestMethod(new MyClass2 { MyString = test });
            Ops.TestMethod(new MyClass2 { MyString = test });
        }
    }
    public class UnitTest1 {
        [Fact]
        public void StackOverflowQuestion() {
            // Arrange
            var arg1 = "1";
            var arg2 = "2";
            var dbOperations = Substitute.For<IDbOperations>();
            var myClass = new MyClass(dbOperations);
            string test = "test string";
            // Act
            myClass.MyMethod(arg1, arg2, test);
            // Assert            
            dbOperations.Received(2).TestMethod(Arg.Is<MyClass2>(a => a.MyString == test));
        }
    }
