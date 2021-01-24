    using Microsoft.ProjectOxford.Vision;
    using Microsoft.ProjectOxford.Vision.Contract;
    using System;
    using System.Configuration;
    using System.IO;
    
    namespace VisionClient
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                AnalyzeImage();
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
    
            private static void AnalyzeImage()
            {
                var apiKey = ConfigurationManager.AppSettings["VisionApiSubscriptionKey"];
                var apiRoot = "https://eastus2.api.cognitive.microsoft.com/vision/v1.0";
                var visionClient = new VisionServiceClient(apiKey, apiRoot);
    
                var visualFeats = new VisualFeature[]
                {
                    VisualFeature.Description,
                    VisualFeature.Faces
                };
    
                Stream imageStream = File.OpenRead("satyaNadella.jpg");
    
                try
                {
                    AnalysisResult analysisResult = visionClient.AnalyzeImageAsync(imageStream, visualFeats).Result;
                    foreach(var caption in analysisResult.Description.Captions)
                    {
                        Console.WriteLine("Description: " + caption.Text);
                    }
                }
                catch (ClientException e)
                {
                    Console.WriteLine("Vision client error: " + e.Error.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
