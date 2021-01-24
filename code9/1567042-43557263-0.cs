    [TestClass()]
    public class NoEmptyAttributeTests
    {
        [TestMethod]
        public void GetValidationResult_ListLongWithElements_ReturnsNull()
        {
            object obj = new object();
            object value = new List<long> { 1, 2 };
            ValidationContext ctx = new ValidationContext( obj ) { MemberName = "Foo" };
            var noempty = new NoEmptyAttribute();
            var result = noempty.GetValidationResult( value, ctx );
            Assert.IsNull( result );
        }
        [TestMethod]
        public void GetValidationResult_ListLongEmpty_ReturnsCannotBeEmpty()
        {
            object obj = new object();
            object value = new List<long>();
            ValidationContext ctx = new ValidationContext( obj ) { MemberName = "Foo" };
            var noempty = new NoEmptyAttribute();
            var result = noempty.GetValidationResult( value, ctx );
            Assert.IsNotNull( result );
            Assert.AreEqual( "Foo can not bt empty", result.ErrorMessage );
        }
        [TestMethod]
        public void GetValidationResult_ListLongNull_ReturnsCannotBeEmpty()
        {
            object obj = new object();
            object value = null;
            ValidationContext ctx = new ValidationContext( obj ) { MemberName = "Foo" };
            var noempty = new NoEmptyAttribute();
            var result = noempty.GetValidationResult( value, ctx );
            Assert.IsNotNull( result );
            Assert.AreEqual( "Foo can not bt empty", result.ErrorMessage );
        }
    }
