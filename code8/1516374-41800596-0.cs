    using System;
    using System.Speech.Recognition;
    using System.Threading;
    //using System.Speech.Synthesis;
    
    namespace Voice_Recognation
    {
        class Program
        {
            static void Main(string[] args)
            {
                SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
                recEngine.SetInputToDefaultAudioDevice();  
    
                Choices commands = new Choices();
                commands.Add(new string[] { "say Hi", "say Hello"});
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(commands);
                Grammar g = new Grammar(gb);
    
                recEngine.LoadGrammarAsync(g);
                
    
                recEngine.SpeechRecognized += recEngine_SpeechRecognized;
                Console.WriteLine("Starting asynchronous recognition...");
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
                
                // Wait 30 seconds, and then cancel asynchronous recognition.
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
    
            // Create a simple handler for the SpeechRecognized event
            static void recEngine_SpeechRecognized (object sender, SpeechRecognizedEventArgs e)
            {
                Console.WriteLine("Speech recognized: {0}", e.Result.Text);
                switch(e.Result.Text){
                    case "say Hello":
                        Console.WriteLine("you said hi"); 
                    break;
                    default:
                    break;
                }
            }
    
        }
    }
