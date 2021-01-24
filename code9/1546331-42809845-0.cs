    IForm<PatientForm> newForm;
    
    public void BuildForm()
            {
                if (dateFirstAnswer.AddSeconds(30) > DateTime.Now)
                {
                    newForm = new FormBuilder<PatientForm>()
                            .Message(ResourceStringExtentionsPatientForm.IntroForm.Spintax())
                            .OnCompletion(async (context, profileForm) =>
                            {
                                string message = ResourceStringExtentionsPatientForm.OutroForm.Spintax();
                                await context.PostAsync(message);
                            })
                            .Build();
                }
            }
