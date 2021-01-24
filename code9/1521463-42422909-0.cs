    private IForm<SampleForm> BuildFeedbackModelForm()
        {
            var builder = new FormBuilder<SampleForm>();
            return builder.Field(new FieldReflector<SampleForm>(nameof(SampleForm.Question))
                    .SetType(typeof(string))
                    .SetDefine(async (state, field) => await SetOptions(state, nameof(SampleForm.Answer), field))
                    .SetValidate(async (state, value) => await ValidateFdResponseAsync(value, state, nameof(SampleForm.Answer)))).Build();
        }
		
		private async Task<bool> SetOptions(SampleForm state, string v, Field<SampleForm> field)
        {
		return true;
        }
		
		private async Task<ValidateResult> ValidateFdResponseAsync(object response, SyncfusionBotFeedbackForm state, string v)
        {
            bool isValid = false; // chcek if valid
            
			
            ValidateResult validateResult = new ValidateResult
            {
                IsValid = isValid,
                Value = isValid?locresult:null
            };
            if (!isValid)
                validateResult.Feedback = $"message to user.";
            return validateResult;
        }
