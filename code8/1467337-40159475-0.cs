    [TestClass]
    public class BindTwoObservableCollections_test
    {
        [TestMethod]
        public void BindTwoObservableCollections()
        {
            var c1 = new ObservableCollection<int>();
            var c2 = new ObservableCollection<int>();
            c1.Add(1);
            Assert.AreEqual(0, c2.Count);
            var subscription = CollectionHelper.Bind(c1, c2);
            c1.Add(2);
            Assert.AreEqual(1, c2.Count);
            Assert.AreEqual(2, c2[0]);
            c2.Add(3);
            Assert.AreEqual(3, c1.Count);
            Assert.AreEqual(3, c1[2]);
            c2.Remove(2);
            Assert.AreEqual(2, c1.Count);
            subscription.Dispose();
            c2.Remove(3);
            Assert.AreEqual(2, c1.Count);
        }
    }
    public static class CollectionHelper
    {
        public static IDisposable Bind<T>(
            ObservableCollection<T> c1,
            ObservableCollection<T> c2)
        {
            var fromC1Subscription = InternalBind(c1, c2);
            var fromC2Subscription = InternalBind(c2, c1);
            return new Disposable(() =>
            {
                fromC1Subscription?.Dispose();
                fromC2Subscription?.Dispose();
            });
        }
        private static IDisposable InternalBind<T>(
            ObservableCollection<T> from,
            ObservableCollection<T> to)
        {
            NotifyCollectionChangedEventHandler onFromChanged =
                (s, e) =>
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            foreach (T added in e.NewItems)
                                if (!to.Contains(added))
                                    to.Add(added);
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            foreach (T removed in e.OldItems)
                                to.Remove(removed);
                            break;
                        //other cases...
                        default:
                            break;
                    }
                };
            from.CollectionChanged += onFromChanged;
            return new Disposable(() => { from.CollectionChanged -= onFromChanged; });
        }
        //public static IDisposable Bind<T1, T2>(
        //    ObservableCollection<T1> c1,
        //    ObservableCollection<T2> c2,
        //    Func<T1, T2> converter1,
        //    Func<T2, T1> converter2)
        //{
        //    todo...
        //}
    }
    public class Disposable : IDisposable
    {
        public Disposable(Action onDispose)
        {
            _onDispose = onDispose;
        }
        public void Dispose()
        {
            _onDispose?.Invoke();
        }
        private Action _onDispose;
    }
