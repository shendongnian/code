    public class SomeClass
    {
        public SomeClass(IOptions<EmailConfigurationSettings> emailSettings) // dependency injection works in your webapp
        {
            var loadEmail = new LoadEmailSettingsFromAppSettings(emailSettings); // send EmailSettings to your other class in your class library
            //(...)
        }
    }
        
