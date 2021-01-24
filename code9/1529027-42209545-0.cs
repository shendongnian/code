    [TestMethod]
        [TestCategory("Reactive")]
        public async Task PagingReactiveUITest()
        {
            ReactiveList<int> SourceList = new ReactiveList<int>();
            for (int i = 0; i < 100; i++)
            {
                SourceList.Add(i);
            }
            Tuple<int, int> pageWindow = new Tuple<int, int>(0, 10);
            //ReactiveComamnd that triggers paging
            ReactiveCommand<Unit> updatePaging =
                ReactiveCommand.CreateAsyncObservable<Unit>((_) =>
                {
                    pageWindow = new Tuple<int, int>(10, 20);
                    return Observable.Return(Unit.Default);
                });
            var PagedList =
                SourceList
                .CreateDerivedCollection(
                    x => x,
                    filter: (item) => item >= pageWindow.Item1 && item < pageWindow.Item2,
                    signalReset: updatePaging);
            Assert.AreEqual(PagedList.First(), 0);
            Assert.AreEqual(PagedList.Last(), 9);
            //Trigger Paging
            await updatePaging.ExecuteAsync(null);
            Assert.AreEqual(PagedList.First(), 10);
            Assert.AreEqual(PagedList.Last(), 19);
        }
