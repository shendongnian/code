    [Test]
        public void Api_RetrieveTakes3Seconds_SomethingReturned()
        {
            mockConnector.Stub(c => c.Retrieve()).Return(Task.Delay(3000).ContinueWith(c => "Something").Result);
            topwatch sw = new Stopwatch();
            sw.Start();
            var response = api.GetSomething();
            sw.Stop();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(3000));        }
     
        [Test]
        public void Api_RetrieveTakes8Seconds_TimeOutExceptionThrown()
        {
            mockConnector.Stub(c => c.Retrieve()).Return(Task.Delay(8000).ContinueWith(c => "Something").Result);
			
			Assert.Throws(Exception, ()=> api.GetSomething());
        }
