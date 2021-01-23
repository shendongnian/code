    using (speechEngine)
          {
            var t = new Thread(() =>
            {
              speechEngine.SetInputToWaveFile(@"C:\AudioAssets\speechSample.wav");
              speechEngine.LoadGrammar(dictationGrammar);
    
              speechEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);
              speechEngine.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(SpeechHypothesizedHandler);
              speechEngine.Recognize();
            });
            t.Start();
            t.Join();
    
          }
     }
