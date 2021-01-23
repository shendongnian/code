    kernel.Bind(typeof(IList<>)).To(typeof(List<>)).InSingletonScope();
    kernel.Bind(typeof(List<>)).ToSelf().InSingletonScope();
    var list1 = kernel.Get<IList<string>>();
    var list2 = kernel.Get<List<string>>();
    Assert.IsTrue(list1.Equals(list2)); // fails as per your question
    kernel.Bind(typeof(IList<>), typeof(List<>)).To(typeof(List<>)).InSingletonScope();
    var list1 = kernel.Get<IList<string>>();
    var list2 = kernel.Get<List<string>>();
    Assert.IsTrue(list1.Equals(list2)); // passes
