    [Test]
    public void Test()
    {
        using (var signal = new ManualResetEvent(false))
        {
            var win32 = Mock.Create<IWin32Api>();
            Mock.Arrange(() => win32.FreeResource())
                .DoInstead(() => { signal.Set(); });
            new Action(() => { new Disposable(win32); })();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (!signal.WaitOne(TimeSpan.FromMinutes(1)))
            {
                Assert.Fail("IWin32Api.FreeResource never called");
            }
        }
    }
