    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var logger = Substitute.For<ILogger>();
            try
            {
                Create(logger);
            }
            catch
            {
                logger.CheckErrorMessage("My Message");
            }
        }
        public string Create(ILogger logger)
        {
            try
            {
                throw new Exception("My Message");
            }
            catch (Exception e)
            {
                logger?.LogError(e.Message);
                throw new Exception("An error occurred while attempting to create a user.", e);
            }
        }
    }
    public static class TestExtensions
    {
        public static void CheckErrorMessage(this ILogger logger, string message)
        {
            logger.Received().Log(
                LogLevel.Error,
                Arg.Any<EventId>(),
                Arg.Is<object>(o => o.ToString() == message),
                null,
                Arg.Any<Func<object, Exception, string>>());
        }
    }
