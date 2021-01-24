    public class LoginViewModel: BaseViewModel {   
        private event EventHandler Appearing = delegate { };
    
        public override void OnAppearing() {
            EventHandler handler = null;
            handler = async (sender, e) => {
                Appearing -= handler; //Unsubscribe from event
                await LoginAsync(); // non-blocking async call
            };
            Appearing += handler;//Subscribe to event
            Appearing(this, EventArgs.Empty);//raise event
        }
    
        private ICommand loginCommand = new Command(async () => { 
            await LoginAsync();//non-blocking async call
        };
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
