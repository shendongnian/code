    public class Foo
    {
        public byte? Bar { get; set; }
    }
        [Test]
        public void TestTinyint()
        {
            var result = _sqlConnection.Query<Foo>(@"select 0 as 'Bar' 
                                                    union all select null as 'Bar'");
            Assert.That(result.First().Bar, Is.EqualTo(0));
            Assert.That(result.Last().Bar, Is.Null);
        }
