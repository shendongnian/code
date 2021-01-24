    public class ConsistentGuidTests
    {
        [Fact]
        public void Referencewise_Equal_Objects_Should_Generate_Same_Guids()
        {
            var obj = new object();
            var obj2 = obj;
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(obj2);
    
            Assert.True(ReferenceEquals(obj, obj2));
            Assert.Equal(guid1, guid2);
        }
    
        [Fact]
        public void ValueObjects_Of_DifferentTypes_Should_Generate_Different_Guids()
        {
            var obj = new object();
            var other = new int();
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(other);
    
            Assert.NotEqual(guid1, guid2);
        }
    
        [Fact]
        public void ValueObjects_With_Same_Values_Should_Generate_Same_Guids()
        {
            var obj = 123;
            var other = 123;
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(other);
    
            Assert.False(ReferenceEquals(obj, other));
            Assert.Equal(guid1, guid2);
        }
    
        [Fact]
        public void ValueObjects_With_Different_Values_Should_Generate_Different_Guids()
        {
            var obj = 123;
            var other = 124;
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(other);
    
            Assert.NotEqual(guid1, guid2);
        }
    
        class AReferenceType
        {
            public int SomeProperty { get; set; }
            public string SomeOtherProperty { get; set; }
    
            public AReferenceType(int a, string b)
            {
                SomeProperty = a;
                SomeOtherProperty = b;
            }
    
            public override int GetHashCode()
            {
                return ConsistentGuid.Hash(new object[]
                {
                    SomeProperty,
                    SomeOtherProperty
                });
            }
        }
    
        [Fact]
        public void ReferenceObjects_With_Same_Values_Should_Generate_Same_Guids()
        {
            var a = 123;
            var b = "asd";
    
            var obj = new AReferenceType(a, b);
            var other = new AReferenceType(a, b);
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(other);
    
            Assert.False(ReferenceEquals(obj, other));
            Assert.Equal(obj.GetHashCode(), other.GetHashCode());
            Assert.Equal(guid1, guid2);
        }
    
        [Fact]
        public void ReferenceObjects_With_Different_Values_Should_Generate_Different_Guids()
        {
            var a = 123;
            var b = "asd";
    
            var obj = new AReferenceType(a, b);
            var other = new AReferenceType(a + 1, b);
    
            var guid1 = ConsistentGuid.Generate(obj);
            var guid2 = ConsistentGuid.Generate(other);
                
            Assert.NotEqual(guid1, guid2);
        }
    }
