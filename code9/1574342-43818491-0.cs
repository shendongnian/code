        public class MappingDataTest : CommonTestData
    {
        public Mock<IMapper> MappingData()
        {
            var mappingService = new Mock<IMapper>();
            UserDetail im = getUserDetail(); // get value of UserDetails
    
            mappingService.Setup(m => m.Map<UserDetail, UserDetailViewModel>(It.IsAny<UserDetail>)).Returns(interview);
            mappingService.Setup(m => m.Map<UserDetailViewModel, UserDetail>(It.IsAny<UserDetailtViewModel>)).Returns(im);
    
            return mappingService;
        }
    }
