    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Newtonsoft.Json;
    
    namespace BuildTasks
    {
    	public class UploadSymbolsTask : Task
    	{
    		[Required]
    		public string DsymFolder { get; set; }
    
    		[Required]
    		public string InsightsApiKey { get; set; }
    
    		[Required]
    		public string MobileCenterApiKey { get; set; }
    
    		[Required]
    		public string MobileCenterApplicationName { get; set; }
    
    		[Required]
    		public string MobileCenterUser { get; set; }
    
    		public override bool Execute()
    		{
    			WriteLogMessage($"Executing {nameof(UploadSymbolsTask)}.");
    
    			if (string.IsNullOrEmpty(InsightsApiKey))
    			{
    				WriteLogMessage($"{nameof(InsightsApiKey)} can not be empty.");
    				return false;
    			}
    
    			if (string.IsNullOrEmpty(DsymFolder))
    			{
    				WriteLogMessage($"{nameof(DsymFolder)} can not be empty.");
    				return false;
    			}
    			if (!Directory.Exists(DsymFolder))
    			{
    				WriteLogMessage($"{nameof(DsymFolder)} does not exist.");
    				return false;
    			}
    
    			try
    			{
    
    				// curl -F "dsym=@yourAppDsym.zip;type=application/zip" https://xaapi.xamarin.com/api/dsym?apikey=[yourApiKey]
    				var tmpFileName = Path.GetTempFileName();
    				// we're just forcing a temporary file name - gettempfile creates it as well, createfromdirectory crashes if it exists.
    				File.Delete(tmpFileName);
    				ZipFile.CreateFromDirectory(DsymFolder, tmpFileName, CompressionLevel.Fastest, false);
    				WriteLogMessage($" Created tmp ZipFile to upload symbols at \"{tmpFileName}\".");
    
    				ExecuteXamarinInsightsUpload(tmpFileName);
    				var awaiter = System.Threading.Tasks.Task.Run(() => ExecuteMobileCenterUploadAsync(tmpFileName)).GetAwaiter();
    				awaiter.GetResult();
    
    				return true;
    			}
    			catch (Exception e)
    			{
    				WriteLogMessage($"Error occured: {e.ToString()}");
    				return false;
    			}
    		}
    
    		private async System.Threading.Tasks.Task ExecuteMobileCenterUploadAsync(string fileName)
    		{
    			WriteLogMessage(" Uploading file to Mobile Center API ...");
    			//	https://docs.mobile.azure.com/api/#/crash
    			//	https://mobile.azure.com/users/USER/apps/APPNAME/crashes/symbols
    
    			using (var client = new HttpClient())
    			{
    				client.DefaultRequestHeaders.TryAddWithoutValidation("X-API-Token", $"{MobileCenterApiKey}");
    				WriteLogMessage("  Retrieving upload id and destination ...");
    				var clientCallback = Guid.NewGuid().ToString();
    				var postContent = new StringContent($"{{ \"symbol_type\" : \"Apple\", \"client_callback\" : \"{clientCallback}\"}}", Encoding.UTF8, "application/json");
    				var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(5)).Token;
    				var symbolUploadInitUrl = $"https://api.mobile.azure.com/v0.1/apps/{MobileCenterUser}/{MobileCenterApplicationName}/symbol_uploads";
    				WriteLogMessage($"  Initializing Symbol upload using {symbolUploadInitUrl} ...");
    				var uploadRequest = await client.PostAsync(
    					symbolUploadInitUrl,
    					postContent,
    					cancellationToken);
    				var symbolUploadInitializeResult = JsonConvert.DeserializeObject<MobileCenterStartSymbolUploadResponse>(await uploadRequest.Content.ReadAsStringAsync());
    
    				WriteLogMessage($"  Uploading as symbol {symbolUploadInitializeResult.symbol_upload_id} to {symbolUploadInitializeResult.upload_url} ...");
    
    				WriteLogMessage("  Uploading file ...");
    				using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
    				{
    					using (var streamContent = new StreamContent(fileStream))
    					{
    						client.DefaultRequestHeaders.TryAddWithoutValidation("x-ms-blob-type", "BlockBlob");
    						var uploadResult = await client.PutAsync(symbolUploadInitializeResult.upload_url, streamContent);
    						WriteLogMessage($"  Response: {uploadResult.StatusCode}");
    						client.DefaultRequestHeaders.Remove("x-ms-blob-type");
    					}
    				}
    
    				var symbolCommitUrl = $"https://api.mobile.azure.com/v0.1/apps/{MobileCenterUser}/{MobileCenterApplicationName}/symbol_uploads/{symbolUploadInitializeResult.symbol_upload_id}";
    				WriteLogMessage($"  Commiting upload using {symbolCommitUrl} ...");
    				
    			var commitRequestMessage = new HttpRequestMessage(
    					new HttpMethod("PATCH"), symbolCommitUrl);
    				commitRequestMessage.Content = new StringContent("{ \"status\" : \"committed\" }", Encoding.UTF8, "application/json");
    				using (var commitResponse = await client.SendAsync(
    					commitRequestMessage, 
    					new CancellationTokenSource(TimeSpan.FromMinutes(5)).Token))
    				{
    					var responseContent = await commitResponse.Content.ReadAsStringAsync();
    					var commitResponseDeserialized = JsonConvert.DeserializeObject<MobileCenterSymbolUploadResultResponse>(responseContent);
    					WriteLogMessage($"  Response: {commitResponseDeserialized.status}");
    				}
    
    				WriteLogMessage(" Done.");
    			}
    		}
    
    
    		private void ExecuteXamarinInsightsUpload(string tmpFileName)
    		{
    			using (var client = new WebClient())
    			{
    				client.Headers.Add(HttpRequestHeader.ContentType, "application/zip"); ;
    				WriteLogMessage(" Uploading file to Xamarin.Insights API ...");
    				var response = client.UploadFile(new Uri($"https://xaapi.xamarin.com/api/dsym?apikey={InsightsApiKey}", UriKind.Absolute), tmpFileName);
    				WriteLogMessage($"  Response: {Encoding.ASCII.GetString(response)}");
    				WriteLogMessage(" Done.");
    			}
    		}
    
    		private void WriteLogMessage(string message)
    		{
    			Log.LogMessage(MessageImportance.High, $"{DateTime.Now.ToString("T")} {message}");
    		}
    	}
    
    	public class MobileCenterStartSymbolUploadResponse
    	{
    		public string symbol_upload_id { get; set; }
    		public string upload_url { get; set; }
    		public DateTime expiration_date { get; set; }
    	}
    
    
    	public class MobileCenterSymbolUploadResultResponse
    	{
    		public string symbol_upload_id { get; set; }
    		public string app_id { get; set; }
    		public string status { get; set; }
    		public string symbol_type { get; set; }
    		public Symbol[] symbols { get; set; }
    		public string origin { get; set; }
    	}
    
    	public class Symbol
    	{
    		public string symbol_id { get; set; }
    		public string type { get; set; }
    		public string app_id { get; set; }
    		public string platform { get; set; }
    		public string url { get; set; }
    		public string origin { get; set; }
    		public string[] alternate_symbol_ids { get; set; }
    		public string status { get; set; }
    	}
    
    
    
    }
