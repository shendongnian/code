    public class SignUpViewModel : AbstractViewModel
    {
        
        //all your properties go here...
        public SignupViewModel()
        {
            //Get a reference to your Messenger somehow. Maybe it's a singleton in ViewModelLocator?
            IMessenger messengerReference = ViewModelLocator.Messenger;
            messenger.Register<LoginMessageArgs>(this, OnLoginMessageReceived);
        }
        private OnLoginMessageReceived(LoginMessageArgs message)
        {
            //Do stuff with your message
        }
    }
