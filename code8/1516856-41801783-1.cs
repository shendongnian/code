    public class ProcessCartHandler
    {
        private readonly ISettingProvider<CartSetting> cartSettingProvider;
        
        public ProcessCartHandler(ISettingProvider<CartSetting> cartSettingProvider) {
            this.cartSettingProvider = cartSettingProvider;
        }
        
        public void Handle(ProcessCartHandler command) {
            // Read configuration value
            string cartType = cartSettingProvider.Value.CartType;
            // Use it.
        }
    }
    
