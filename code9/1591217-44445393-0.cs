    public class GDrive : IGDrive
    {
        private readonly Lazy<Task<DriveService>> _driveService;
        public GDrive(Lazy<Task<UserCredential>> userCredential)
        {
            _driveService = new Lazy<Task<DriveService>>(async () =>
                new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = await userCredential.Value,
                    ApplicationName = string.Empty
                }));
        }
        public async Task SomeMethod()
        {
            var service = await _driveService.Value;
            service.DoSomeStuff();
        }
    }
	
