    public class SampleRepoTests
    {
        private readonly AutoMocker _mocker = new AutoMocker();
        private readonly ISampleRepo _sampleRepo;
        private readonly IOptions<SampleOptions> _options = Options.Create(new SampleOptions()
            {FirstSetting = "firstSetting"});
        public SampleRepoTests()
        {
            _mocker.Use(_options);
            _sampleRepo = _mocker.CreateInstance<SampleRepo>();
        }
        [Fact]
        public void Test_Options_Injected()
        {
            var firstSetting = _sampleRepo.GetFirstSetting();
            Assert.True(firstSetting == "firstSetting");
        }
    }
    public class SampleRepo : ISampleRepo
    {
        private SampleOptions _options;
        public SampleRepo(IOptions<SampleOptions> options)
        {
            _options = options.Value;
        }
        public string GetFirstSetting()
        {
            return _options.FirstSetting;
        }
    }
    public interface ISampleRepo
    {
        string GetFirstSetting();
    }
    public class SampleOptions
    {
        public string FirstSetting { get; set; }
    }
