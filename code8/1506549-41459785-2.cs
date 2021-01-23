    public class LoginViewModel : AbstractViewModel
    {
        //all your properties go here...
        IMessenger messengerReference;
        public LoginViewModel()
        {
            //Get a reference to your Messenger somehow. Maybe it's a singleton in ViewModelLocator?
            messengerReference = ViewModelLocator.Messenger;
        }
         //Maybe you call this method when you navigate away from the LoginViewModel, or whenever it makes sense to send this information to your SignupViewModel.
        private void PassLoginInformation()
        {
            messengerReference.Publish<LoginMessageArgs>(new LoginMessageArgs { Username = this.Username }); //etc
        }
    }
