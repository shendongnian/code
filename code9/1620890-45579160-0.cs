    public sealed partial class LoginDialog {
        public Exception Exception { get; private set; }
    
        private async void OkClicked(ContentDialog contentDialog, ContentDialogButtonClickEventArgs args) {
                try {
                    await Validate();
                }
                catch (Exception e) {
                    Exception = e;
                }
            }
    }
    public async Task<bool> ShowLoginDialogAsync(LogInType loginType) {
                
                var loginDialog = new LoginDialog(loginType);
    
                await loginDialog.ShowAsync();
    
                switch (loginDialog.Exception) {
                    case null:
                        break;
                    default:
                        throw loginDialog.Exception;
                }
    
                return loginDialog.Result;
            }
