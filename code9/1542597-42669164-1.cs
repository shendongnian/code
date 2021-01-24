    namespace SampleUnitTest
    {
        [TestClass]
        public class Foo
        {
            [TestMethod]
            public void Bar()
            {
                var p1 = new DateTimePeriod { From = DateTime.MinValue, To = DateTime.MaxValue };
                var p2 = new DateTimePeriod { From = DateTime.MaxValue, To = DateTime.MinValue };
                var x = new Name { AName = "Jack", Valid = p1, Id = "123" };
                var y = new Name { AName = "John", Valid = p2, Id = "321" };
                Assert.AreEqual("John", x.AName);
                Assert.AreEqual(p2, x.Valid);
                Assert.AreEqual("321", x.Id);
            }
        } 
    
        public class Name
        {
            private string id;
            public string Id
            {
                get { return id; }
                set { id = value; }
            }
            private string aName;
            public string AName
            {
                get { return aName; }
                set { aName = value; ; }
            }
            private DateTimePeriod valid;
            public DateTimePeriod Valid
            {
                get { return valid; }
                set { valid = value ; }
            }
        }
    
        public class DateTimePeriod : Period<DateTime>
        {
        }
    
        public class Period<T>
        {
            private T from;
            private T to;
            public Period()
            {
                from = default(T);
                to = default(T);
            }
            public T From
            {
                get { return from; }
                set { from = value; }
            }
            public T To
            {
                get { return to; }
                set { to = value; }
            }
        }
    }
