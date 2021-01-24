    public class Test {
        private readonly IScope _scope;
        public Test(IScope scope) {
            _scope = scope;
        }
        public IList<Foo> Foo() {
            var foo = new FooEntity();
            Result<IList<Foo>> result = _scope.Execute<FooService, IList<Foo>>("f", s => s.GetFoo(foo));
            var value = result.Value;
            return value;
        }
    }
