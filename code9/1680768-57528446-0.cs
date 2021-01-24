        [Test]
        public void should_convert_datetime_to_utc()
        {
            var bar = new UtcDateTimeModelBinder();
            var dateTime = BindModelFromGet<UtcDateTimeModelBinder, DateTime>
                ("fred", "?fred=2019-08-12 00:00:00Z", bar);
            Assert.That(dateTime.Kind, Is.EqualTo(DateTimeKind.Utc));
        }
