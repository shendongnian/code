    using Google.Apis.Auth.OAuth2;
    using Google.Cloud.Speech.V1;
    using Grpc.Auth;
    using System;
    	var speech = SpeechClient.Create( channel );
		var response = speech.Recognize( new RecognitionConfig()
		{
			Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
			SampleRateHertz = 16000,
			LanguageCode = "hu",
		}, RecognitionAudio.FromFile( "888.wav" ) );
		foreach ( var result in response.Results )
		{
			foreach ( var alternative in result.Alternatives )
			{
				Console.WriteLine( alternative.Transcript );
			}
		}
