    using Microsoft.Azure.Search;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Threading;
    namespace AzureSearchTextAnalytics
    {
    class Program
    {
        static string searchServiceName = "<removed>";     // This is the Azure Search service name that you create in Azure
        static string searchServiceAPIKey = "<removed>";   // This is the Primary key that is provided after creating a Azure Search Service
        static string indexName = "textanalytics";
        static SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(searchServiceAPIKey));
        static SearchIndexClient indexClient = serviceClient.Indexes.GetClient(indexName);
        static void Main()
        {
            MakeRequests();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
        static async void MakeRequests()
        {
            // Note, this will create a new Azure Search Index for the text and the key phrases
            Console.WriteLine("Creating Azure Search index...");
            AzureSearch.CreateIndex(serviceClient, indexName);
            // Apply the Machine Learning Text Extraction to retrieve only the key phrases
            Console.WriteLine("Extracting key phrases from processed text... \r\n");
            KeyPhraseResult keyPhraseResult = await TextExtraction.ProcessText();
            Console.WriteLine("Found the following phrases... \r\n");
            foreach (var phrase in keyPhraseResult.KeyPhrases)
                Console.WriteLine(phrase);
            // Take the resulting key phrases to a new Azure Search Index
            // It is highly recommended that you upload documents in batches rather 
            // individually like is done here
            Console.WriteLine("Uploading extracted text to Azure Search...\r\n");
            AzureSearch.UploadDocuments(indexClient, "1", keyPhraseResult);
            Console.WriteLine("Wait 5 seconds for content to become searchable...\r\n");
            Thread.Sleep(5000);
            // Execute a test search 
            Console.WriteLine("Execute Search...");
            AzureSearch.SearchDocuments(indexClient, "Azure Search");
            Console.WriteLine("All done.  Press any key to continue.");
            Console.ReadLine();
        }
    }
    }
