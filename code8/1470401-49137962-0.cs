    var credential = GoogleCredential.FromFile( "privatekey.json" ).CreateScoped( SpeechClient.DefaultScopes );
    var channel = new Grpc.Core.Channel( SpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials() );
    var speech = SpeechClient.Create( channel );
    var streamingCall = speech.StreamingRecognize();
    // Write the initial request with the config.
    await streamingCall.WriteAsync(
    	new StreamingRecognizeRequest()
    	{
    		StreamingConfig = new StreamingRecognitionConfig()
    		{
    			Config = new RecognitionConfig()
    			{
    				Encoding =
    				RecognitionConfig.Types.AudioEncoding.Linear16,
    				SampleRateHertz = 16000,
    				LanguageCode = "hu",
    			},
    			InterimResults = true,
    		}
    	} );
 
