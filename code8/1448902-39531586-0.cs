        [Test]
        public void Should_not_peak_more_than_200_mb()
        {
        	var memoryCap = 200 * 1024 * 1024;
        	var sut = new SystemUnderTest();
            sut.DoMemoryHeavyOperation()
            var peakWorkingSet = Process.GetCurrentProcess().PeakWorkingSet64;
            Assert.That(peakWorkingSet, Is.LessThan(memoryCap));
        }
