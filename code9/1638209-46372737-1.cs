    public class UnitTest1 : IClassFixture<DocumentStoreFixture>
    {
        public class User
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool Internal { get; set; }
            public string UserName { get; set; }
        }
        private readonly DocumentStoreFixture _fixture;
        public UnitTest1(DocumentStoreFixture fixture)
        {
            _fixture = fixture;
            using (var session = _fixture.Store.LightweightSession())
            {                
                session.DeleteWhere<User>(u => true);
                session.StoreObjects(new []
                {
                    new User { FirstName = "Han", LastName = "Solo" },
                    new User { FirstName = "Bob", LastName = "Marley" },
                    new User { FirstName = "Jessie", LastName = "Pinkman"}
                });
                session.SaveChanges();
            }
        }
        [Fact]
        public void Can_Order()
        {            
            using (var session = _fixture.Store.LightweightSession())
            {
                GetList<User>(session, "asc", u => u.LastName, null, null)
                .Select(x => x.LastName)
                .ShouldBe(new []{"Marley", "Pinkman", "Solo"});
                GetList<User>(session, "desc", u => u.LastName, null, null)
                .Select(x => x.LastName)
                .ShouldBe(new []{"Marley", "Pinkman", "Solo"}.Reverse());
            }
        }
        [Fact]
        public void Can_OrderAndPage()
        {            
            using (var session = _fixture.Store.LightweightSession())
            {
                GetList<User>(session, "asc", u => u.FirstName, 1, 1)
                .Select(x => x.FirstName)
                .ShouldBe(new []{"Han"});
            }
        }
    }
    public class DocumentStoreFixture
    {
        public IDocumentStore Store { get; }
        public DocumentStoreFixture()
        {
            Store = DocumentStore.For("host=localhost;database=marten;username=marten;password=marten");
        }
    }
