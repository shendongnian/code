    SpeechRecognizer sr = new SpeechRecognizer();
    sr.SpeechRecognized += (s, e) => {
                Console.WriteLine("Recognized Text :{0}, Confidence {1}",
                                   e.Result.Text,e.Result.Confidence); 
            };
