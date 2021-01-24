            var response = await speech.RecognizeAsync(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                //SampleRateHertz = WAVSampleRate,
                LanguageCode = language,
            }, RecognitionAudio.FromFile(filenameAndPath));
