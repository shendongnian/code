    public class FooServiceTest
    {
        private IFooService _fooService;
        private Mock<IFooRepository> _fooRepository;
		//dummy data expression
		//first parameter is expression
		//second parameter is expected
        public static TheoryData<Expression<Func<Foo, bool>>, object> dataExpression = new TheoryData<Expression<Func<Foo, bool>>, object>()
        {
            { (p) => p.FooName == "Helios", "Helios" },
            { (p) => p.FooDescription == "Helios" && p.FooId == 1, "Helios" },
            { (p) => p.FooId == 2, "Poseidon" },
        };
		//dummy data source
        public static List<Foo> DataTest = new List<Foo>
        {
            new Foo() { FooId = 1, FooName = "Helios", FooDescription = "Helios Description" },
            new Foo() { FooId = 2, FooName = "Poseidon", FooDescription = "Poseidon Description" },
        };
		//constructor
        public FooServiceTest()
        {
            this._fooRepository = new Mock<IFooRepository>();
            this._fooService = new FooService(this._fooRepository.Object);
        }
        [Theory]
        [MemberData(nameof(dataExpression))]
        public void Find_Test(Expression<Func<Foo, bool>> expression, object expected)
        {
            this._fooRepository.Setup(setup => setup.FindAsync(It.IsAny<Expression<Func<Foo, bool>>>()))
                                   .ReturnsAsync(DataTest.Where(expression.Compile()));
            var actual = this._fooService.FindAsync(expression).Result;
			Assert.Equal(expected, actual.FooName);
        }
    }
