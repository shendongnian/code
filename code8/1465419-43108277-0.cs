            AmazonLambdaClient alc = new AmazonLambdaClient(AWSAccessKey, AWSSecretKey, RegionEndpoint.USEast1);
            Amazon.Lambda.Model.InvokeRequest ir = new Amazon.Lambda.Model.InvokeRequest();
            ir.FunctionName = "arn:YOUR_FUNCTIONS_ARN";
            ir.Payload = SOME_JSON_ARGUMENTS;
            var res = alc.Invoke(ir);
            var yourResult = DESERIALIZE_SOMEHOW(res.Payload);
