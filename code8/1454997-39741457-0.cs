         public Task<string> Invoke(dynamic i) {
          var tcs = new TaskCompletionSource<string>();
          // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();
    
            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();
    
            // Speak a string.
            synth.Speak("This example demonstrates a basic use of Speech Synthesizer");
    
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
    
            // Create a new SpeechRecognitionEngine instance.
            SpeechRecognizer recognizer = new SpeechRecognizer();
    
            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices colors = new Choices();
            colors.Add(new string[] { "red", "green", "blue" });
    
            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);
    
            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);
    
            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized += (sender,e) => {
 
               string speech = e.Result.Text;
                //handle custom commands
                switch (speech)
                {
                    case "red":
                     tcs.SetResult("Hello Red");
                    break;
                    case "green":
                     tcs.SetResult("Hello Green");
                    break;
                    case "blue":
                     tcs.SetResult("Hello Blue");
                     break;
                    case "Close":
                     tcs.SetResult("Hello Close");
                    break;
                   default:
                     tcs.SetResult("Hello Not Sure");
                  break;
        }
        
         };
          recognizer.Recognize();
              
           return tcs.Task;
        }
