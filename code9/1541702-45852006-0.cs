    using Prism.Interactivity.InteractionRequest;
    using Prism.Commands;
    public InteractionRequest<IConfirmation> ConfirmInPopup { get; private set; }
    //code
     ConfirmInPopup.Raise(new Confirmation() {
                            Title = "Confirm",
                            Content = new MedInModel
                            {
                                MedOnlyCode = med.MedOnlyCode,
                                MedName = med.MedName,
                                MedNowAmt=10,
                                BoxId=med.BoxId
                            }
                        },t => 
                                if (t.Confirmed)
                                {
                                    
                                }
                             );
