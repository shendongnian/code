        [TestMethod]
        public async Task APossibleTest()
        {
            int importantNumber = 0;
            var proc = Substitute.For<IProcessor>();
            proc.WhenForAnyArgs(processor => processor.Process(Arg.Any<string>()))
                .Do(callInfo =>
                {
                    int cached = importantNumber;
                    // Wait for other threads to fetch the number too (if they were not synchronized).
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                    // This kind of incrementation will check the thread synchronization.
                    // Using a thread-safe Interlocked or other here does not make sense.
                    importantNumber = cached + 1;
                });
            var locker = new Locker(proc, "da horror");
            // Create 10 tasks all attempting to increment the important number.
            Task[] tasks =
                Enumerable
                    .Range(0, 10)
                    // You could create multiple lockers here (with their own processors).
                    .Select(i => Task.Run(() => locker.Go()))
                    .ToArray();
            await Task.WhenAll(tasks);
            Assert.AreEqual(10, importantNumber, "Exactly 10 increments were expected since we have 10 tasks.");
        }
