        [Test]
        public void should_handle_bad_dates()
        {
            var bar = new UtcDateTimeModelBinder();
            var ex = Assert.Throws<Exception>(() => BindModelFromGet<UtcDateTimeModelBinder, DateTime>
                ("fred", "?fred=NotADate", bar));
            Assert.That(ex.Message, Is.EqualTo("Cannot convert value to Utc DateTime"));
        }
