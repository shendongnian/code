    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.WebApi.Patch;
    using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
    using System;
    
    namespace UploadAttachment
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                // Full path to the binary file to upload as an attachment
                string filePath = @"C:\Temp\attach-file.PNG";
                var myCredentials = new VssClientCredentials();
                var connection = new VssConnection(new Uri(@"http://tfsserver:8080/tfs/TeamProjectCollectionName"), myCredentials);
                WorkItemTrackingHttpClient workItemTrackingClient = connection.GetClient<WorkItemTrackingHttpClient>();
                AttachmentReference attachment = workItemTrackingClient.CreateAttachmentAsync(filePath).Result;
                JsonPatchDocument patchDocument = new JsonPatchDocument();
                patchDocument.Add(
                     new JsonPatchOperation()
                     {
                         Operation = Operation.Add,
                         Path = "/relations/-",
                         Value = new
                         {
                             rel = "AttachedFile",
                             url = attachment.Url,
                             attributes = new { comment = "Adding new attachment for Test Case" }
                         }
                     }
                 );
    
                WorkItem result = workItemTrackingClient.UpdateWorkItemAsync(patchDocument, 595).Result;
    
                
    
            }
        }
    }
