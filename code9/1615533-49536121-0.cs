    using System;
    using Google.Apis.Auth.OAuth2;
    using Google.Cloud.Vision.V1;
    using Grpc.Auth;
    
    namespace GoogleVision
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonPath = @"<path to .json credential file>";
    
                var credential = GoogleCredential.FromFile(jsonPath).CreateScoped(ImageAnnotatorClient.DefaultScopes);
    
                var channel = new Grpc.Core.Channel(ImageAnnotatorClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
    
                var client = ImageAnnotatorClient.Create(channel);
    
                var image = Image.FromFile(@"<path to your image file>");
    
                var response = client.DetectLabels(image);
    
                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                        Console.WriteLine(annotation.Description);
                }
            }
        }
    }
