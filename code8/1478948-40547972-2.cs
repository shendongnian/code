     public static IForm<Order> BuildOrderForm()
            {
                return new FormBuilder<Order>()
                    .Field(nameof(RecipientFirstName))
                    .Field(nameof(RecipientLastName))
                    .Field(nameof(RecipientPhoneNumber))
                    .Field(nameof(Note))
                    .Field(new FieldReflector<Order>(nameof(UseSavedSenderInfo))
                        .SetActive(state => state.AskToUseSavedSenderInfo)
                        .SetNext((value, state) =>
                        {
                            var selection = (UseSaveInfoResponse)value;
    
                            if (selection == UseSaveInfoResponse.Edit)
                            {
                                state.SenderEmail = null;
                                state.SenderPhoneNumber = null;
                                return new NextStep(new[] { nameof(SenderEmail) });
                            }
                            else
                            {
                                return new NextStep();
                            }
                        }))
                    .Field(new FieldReflector<Order>(nameof(SenderEmail))
                        .SetActive(state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                        .SetNext(
                            (value, state) => (state.UseSavedSenderInfo == UseSaveInfoResponse.Edit)
                            ? new NextStep(new[] { nameof(SenderPhoneNumber) })
                            : new NextStep()))
                    .Field(nameof(SenderPhoneNumber), state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                    .Field(nameof(SaveSenderInfo), state => !state.UseSavedSenderInfo.HasValue || state.UseSavedSenderInfo.Value == UseSaveInfoResponse.Edit)
                    .Build();
            }
        }
    }
