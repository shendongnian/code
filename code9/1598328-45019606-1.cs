        public class MockUowFactory {
        public static Mock<IUnitOfWork> Get(string dbName) {
            DbContextOptions<YOUR CONTEXT> options = new DbContextOptionsBuilder<YOUR CONTEXT>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            using (var seedContext = new YOURCONTEXT(options)) {
                seedContext.YOURENTITY.AddRange(MockEntityFactory.YOURENTITY);
                seedContext.SaveChanges();
            }
            var context = new YOURCONTEXT(options);
            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(m => m.Context).Returns(context);
            mockUow.Setup(m => m.Save()).Returns(() => context.SaveChanges().ToString());
            return mockUow;
        }
    }
