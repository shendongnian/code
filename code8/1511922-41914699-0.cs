    using System;
    using System.IO;
    using Amazon;
    using Amazon.Polly;
    using Amazon.Polly.Model;
    namespace AwsPollySO1
    {
        class Program
        {
            public static void Main(string[] args)
            {
                AmazonPollyClient client = new AmazonPollyClient("yourID", "yourSecretKey", RegionEndpoint.USEast1);
                SynthesizeSpeechRequest request = new SynthesizeSpeechRequest();
                request.OutputFormat = OutputFormat.Mp3;
                request.Text = "This is my first conversion";
                request.TextType = TextType.Text;
                request.VoiceId = VoiceId.Nicole;
                SynthesizeSpeechResponse response = client.SynthesizeSpeech(request);
                Console.WriteLine("ContentType: " + response.ContentType);
                Console.WriteLine("RequestCharacters: " + response.RequestCharacters);
                FileStream destination = File.Open(@"c:\temp\myfirstconversion.mp3", FileMode.Create);
                response.AudioStream.CopyTo(destination);
                Console.WriteLine("Destination length: {0}", destination.Length.ToString());
                destination.Close();
                Console.Read();
            }
        }
    }
