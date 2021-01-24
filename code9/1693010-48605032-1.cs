        [TestMethod]
        public void TestMethod1()
        {
            using (TestUtils.WithScheduler(ImmediateScheduler.Instance))
            {
                var bar = new Bar();
                var foo = new Foo();
                foo.List.Add(bar);
                bar.IsSelected = true;
                Assert.AreEqual(bar, foo.SelectedItem);
            }
        }
