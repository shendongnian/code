    public string FunctionHandler(JObject input, ILambdaContext context)
    {
        param = input["param"].Value<string>();
        param1 = input["param1"].Value<string>();
        param.ToUpper() + " " + param1.ToUpper();
    }
