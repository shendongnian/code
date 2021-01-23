        [Test]
        public void TestDynamicsTest()
        {
            var query = @"select 1 as 'Foo', 2 as 'Bar' union all select 3 as 'Foo', 4 as 'Bar'";
            var result = _connection.Query<dynamic>(query);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.True(result.Select(x => x.Foo == 1).First());
            Assert.True(result.Select(x => x.Bar == 4).Last());
        }
