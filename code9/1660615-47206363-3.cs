    public class LoginViewModel: BaseViewModel {
 
        public LoginViewModel() : base() {
            Appearing += handler;//Subscribe to event
        }
  
        private event EventHandler Appearing = delegate { };
        
        private async void handler(object sender, EventArgs e) {
            Appearing -= handler; //Unsubscribe from event
            await LoginAsync(); // non-blocking async call
        }
    
        public override void OnAppearing() {
            Appearing(this, EventArgs.Empty);//raise event
        }
    
        private ICommand loginCommand = new Command(async () => { 
            await LoginAsync();//non-blocking async call
        });
        public ICommand LoginCommand {
            get {
                return loginCommand;
            }
        }
        private async Task LoginAsync() {
            var validationResult = await SomeLongRunningValidation();
            if (!validationResult.Authenticated) {
                await navigation.DisplayAlert("Error", "Authentication failed.  Try again?", "Yes", "No");
            }
        }
    }
