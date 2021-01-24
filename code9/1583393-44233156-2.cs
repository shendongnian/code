    public class Function
    {
        public PreSignUp_SignUp FunctionHandler(PreSignUp_SignUp input, ILambdaContext context)
        {
			context.Logger.LogLine("Auto-confirming everything!");
	        input.Response = new PreSignUpSignUpResponse {
		        AutoConfirmUser = true,
				// you can only auto-verify email or phone if it's present in the user attributes
				AutoVerifyEmail = input.Request.UserAttributes.ContainsKey("email"),
				AutoVerifyPhone = input.Request.UserAttributes.ContainsKey("phone_number") 
			};
	        return input;
        }
    }
