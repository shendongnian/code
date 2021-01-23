    public class BasicContainer : UserControl {
        public async Task CreateMultipleActivityControls() {
            var platform = PlatformProvider.Current;
            for (var i = 0; i < 1000; i++) {
                await platform.OnUIThreadAsync(() => {    
                    var c = new ActivityControl();     
                    c.LoadSubControls();
                });    
            }
        }
    }
