    class AutoVerifyEmail
    {
        public AutoVerifyEmail() { }
        
        public JObject AutoVerifyEmailPreSignup(JObject input, ILambdaContext context)
        {
            //Console.Write(input); //Print Input
            input["response"]["autoVerifyEmail"] = true;
            input["response"]["autoConfirmUser"] = true;
            return input;
        }
    }
