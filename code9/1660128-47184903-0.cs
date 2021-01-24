        [TestMethod]
        public void DetailPage_ShouldBeOfFooType()
        {
            var target = new Target();
            Assert.IsTrue(target is IHasDetailPage<Foo>);
        }
        public class Foo { }
        public class Bar : Foo { }
        public interface IHasDetailPage<out TViewModel> where TViewModel : Foo
        {
            TViewModel GetViewModel();
        }
        public class Target : IHasDetailPage<Bar>
        {
            public Bar GetViewModel() { return null; }
        }
