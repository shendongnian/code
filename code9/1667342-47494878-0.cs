    [Theory, ClassData(typeof(FooTestCases))]
    public void ClassDataTest(Foo sut)
    {
        var bar = 1; // Essential no-op, Breakpoint 'B3'
    }
    private class FooTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Foo() };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
