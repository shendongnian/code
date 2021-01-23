    public delegate void SomeDelegate();
    public class Foo
    {
        public virtual async Task<int> MethodWithDelegate(string something, SomeDelegate d)
        {
            return await Task.FromResult(1);
        }
    }
    [Test]
    public void DelegateInArgument()
    {
        var sub = Substitute.For<Foo>();
        sub.MethodWithDelegate("1", Arg.Any<SomeDelegate>()).Returns(1);
        Assert.AreEqual(1, sub.MethodWithDelegate("1", () => {}).Result);
        Assert.AreNotEqual(1, sub.MethodWithDelegate("2", () => {}).Result);
    }
