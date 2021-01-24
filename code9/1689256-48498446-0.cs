    public async Task StartAsync(IDialogContext context)
    {
        var state = new ApplyForm();
    
        CustomerAccount customerAccount;
        FormDialog<ApplyForm> form;
        if (context.UserData.TryGetValue<CustomerAccount>("CustomerAccount", out customerAccount))
        {
            state.FirstName = customerAccount.FirstName;
            state.EmailAddress = customerAccount.Email;
    
            form = new FormDialog<ApplyForm>(
                state,
                BuildForm2,
                FormOptions.PromptInStart);
        }
        else
        {
            form = new FormDialog<ApplyForm>(
                  state,
                  BuildForm1,
                  FormOptions.PromptInStart);
        }
        context.Call(form, this.AfterBuildForm);
    }
    
    [Prompt("What is your **{&}**?")]
    public string FirstName { get; set; }
    
    [Prompt("What is your **{&}**?")]
    public string EmailAddress { get; set; }
    
    [Numeric(0, 15)]
    [Prompt("How many adults will attend?")]
    public int AdultOptionCount { get; set; }
    
    [Numeric(0, 15)]
    [Prompt("How many children will attend?")]
    public int ChildOptionCount { get; set; }
    
    public static IForm<ApplyForm> BuildForm1()
    {
        var form = new FormBuilder<ApplyForm>()
            .Field(nameof(FirstName))
            .Field(nameof(EmailAddress))
            .Field(nameof(AdultOptionCount),
                validate: async (state, value) =>
                {
                    var result = new ValidateResult { Value = value };
                    result.IsValid = IsInteger(value);
                    return result;
                })
                .Field(nameof(ChildOptionCount),
                validate: async (state, value) =>
                {
                    var result = new ValidateResult { Value = value };
                    result.IsValid = IsInteger(value);
                    return result;
                })
                .Build();
    
        return (IForm<ApplyForm>)form;
    }
    
    public static IForm<ApplyForm> BuildForm2()
    {
        var form = new FormBuilder<ApplyForm>()
                .Field(nameof(AdultOptionCount),
                validate: async (state, value) =>
                {
                    var result = new ValidateResult { Value = value };
                    result.IsValid = IsInteger(value);
                    return result;
                })
                .Field(nameof(ChildOptionCount),
                validate: async (state, value) =>
                {
                    var result = new ValidateResult { Value = value };
                    result.IsValid = IsInteger(value);
                    return result;
                })
                .Build();
    
        return (IForm<ApplyForm>)form;
    }
    //other code goes here
