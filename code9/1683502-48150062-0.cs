    RecognitionConfig config = new RecognitionConfig();
    config.Encoding = RecognitionConfig.Types.AudioEncoding.Linear16;
    config.SampleRateHertz = 32000;
    config.LanguageCode = "en";
    await streamingCall.WriteAsync(
        new StreamingRecognizeRequest()
        {
            StreamingConfig = new StreamingRecognitionConfig()
            {
                Config = config, // You are missing this line
                InterimResults = true,
            }
        });
