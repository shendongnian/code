    public class ProfileRepositoryTests
    {
        //this class is only reposible to handle data from the IProfileDataRepository
        private readonly ProfilesRepository _profilesRepository;
        private readonly Mock<IProfileDataRepository> _moqProfileDataProvider;
        public ProfileRepositoryTests()
        {
            _moqProfileDataProvider = new Mock<IProfileDataRepository>();
            _profilesRepository = new ProfilesRepository(_moqProfileDataProvider.Object);
        }
        [Fact]
        public void Get_Succes_NoProfiles()
        {
            _moqProfileDataProvider.Setup(x => x.Get()).Returns(new List<Profile>());
            var profiles = _profilesRepository.GetAllProfiles();
            
            Assert.AreEqual(0, profiles.Count);
        }
        [Fact]
        public void Get_Succes_AllProfiles()
        {
            _moqProfileDataProvider.Setup(x => x.Get()).Returns(new List<Profile>
            {
                new Profile {UserID = "123"}
            });
            var profiles = _profilesRepository.GetAllProfiles();
            Assert.AreEqual(1, profiles.Count);
            Assert.AreEqual("123", profiles.First().UserID);
            //test more properties
        }
        [Fact]
        public void GetProfilesMatchingUserID_userId_null_Throws_Error()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => _profilesRepository.GetProfilesMatchingUserID(null));    
        }
    }
