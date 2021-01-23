    public class BasicContainer : UserControl {
        public async Task CreateMultipleActivityControls() {
            var platform = PlatformProvider.Current;
            await platform.OnUIThreadAsync(() => {
                for (var i = 0; i < 1000; i++) {                    
                    var c = new ActivityControl();     
                    c.LoadSubControls();
                }    
            });
        }
    }
