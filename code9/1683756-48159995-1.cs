    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Speech.Recognition;
      static void Main(string[] args)
      {
        using (SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine())
        {
           recEngine.SpeechRecognized += 
                 new EventHandler<SpeechRecognizedEventArgs>(recEngine_SpeechRecognized);
           recEngine.AudioStateChanged += 
                 new EventHandler<AudioStateChangedEventArgs>(recEngine_AudioStateChange);
           Choices commands = new Choices();
           commands.Add(new string[] { "dollar", "euro" });
           GrammarBuilder gBuilder = new GrammarBuilder();
           gBuilder.Append(commands);
           Grammar grammar = new Grammar(gBuilder);
           recEngine.SetInputToDefaultAudioDevice();
           recEngine.LoadGrammarAsync(grammar);
           recEngine.RequestRecognizerUpdate();
           recEngine.RecognizeAsync(RecognizeMode.Multiple);
           Console.ReadKey();
           recEngine.SpeechRecognized -= recEngine_SpeechRecognized;
           recEngine.AudioStateChanged -= recEngine_AudioStateChange;
        }
      }
      internal static void recEngine_AudioStateChange(object sender, AudioStateChangedEventArgs e)
      {
         Console.WriteLine("Current AudioLevel: {0}", e.AudioState);
      }
      internal static void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
      {
         switch (e.Result.Text)
         {
            case "dollar":
               Console.WriteLine("10kr");
               break;
            case "euro":
               Console.WriteLine("A lot more");
               break;
         }
      }
