    [TestFixture]
    public class ContactsUseCaseTests : MyUnitTestBase {
        private Mock<IMyModelContext> _mockDbContext;
        private MockDbSet<Contact> _mockDbSetContact;
        private IContactsUseCase _usecase;
    
        [SetUp]
        public void InitializeTest() {
            SetupTestData();
            _usecase = new ContactsUseCase(_mockDbContext.Object);
        }
    
        [Test]
        public void TestSaveEntryNotNewButNotFound() {
            // Arrange
            Contact contact = new Contact { ContactId = 99, FirstName = "Leo", LastName = "Miller" };
    
            // Act
            _usecase.SaveContact(contact, false);
    
            // Assert
            _mockDbSetContact.Verify(x => x.Add(It.IsAny<Contact>()), Times.Once);
            _mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    
        private void SetupTestData() {
            var contacts = new List<Contact>();
    
            contacts.Add(new Contact { ContactId = 12, FirstName = "Joe", LastName = "Smith" });
            contacts.Add(new Contact { ContactId = 17, FirstName = "Daniel", LastName = "Brown" });
            contacts.Add(new Contact { ContactId = 19, FirstName = "Frank", LastName = "Singer" });
    
            _mockDbSetContact = new MockDbSet<Contact>()
                .SetupAddAndRemove()
                .SetupSeedData(contacts)
                .SetupLinq();
    
            _mockDbContext = new Mock<IMyModelContext>();
            _mockDbContext.Setup(c => c.ContactList).Returns(_mockDbSetContactList.Object);
            _mockDbContext.Setup(c => c.Contact).Returns(_mockDbSetContact.Object);
            _mockDbContext.Setup(c => c.Entry(It.IsAny<Contact>()).Returns(new DbEntityEntry());
        }
    }
