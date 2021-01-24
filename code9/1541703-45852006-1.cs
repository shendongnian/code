    using Prism.Interactivity.InteractionRequest;
    public class ConfirmMedInViewModel : IInteractionRequestAware
    {
            public INotification Notification
            {
                get
                {
                    return _confirmation;
                }
                set
                {
                    SetProperty(ref _confirmation, (IConfirmation)value);
                }
            }
            public Action FinishInteraction { get; set; 
    }
