    public class Base64Decoder
    {
          public static void Main ()
          {
                string inputText = "This is some text.";
                Console.Out.WriteLine ("Input text: {0}", inputText);
                byte [] bytesToEncode = Encoding.UTF8.GetBytes (inputText);
     
                string encodedText = Convert.ToBase64String (bytesToEncode);
                Console.Out.WriteLine ("Encoded text: {0}", encodedText);
     
                byte [] decodedBytes = Convert.FromBase64String (encodedText);
                string decodedText = Encoding.UTF8.GetString (decodedBytes);
                Console.Out.WriteLine ("Decoded text: {0}", decodedText);
     
                Console.Out.Write ("Press enter to finish.");
                Console.In.ReadLine ();
     
                return;
          }
    }
