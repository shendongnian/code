    private async Task<OcrResults> UploadAndRecognizeImageAsync(string imageFilePath, string language)
		{
			// -----------------------------------------------------------------------
			// KEY SAMPLE CODE STARTS HERE
			// -----------------------------------------------------------------------
			//
			// Create Project Oxford Vision API Service client
			//
			VisionServiceClient VisionServiceClient = new VisionServiceClient(SubscriptionKey);
			Log("VisionServiceClient is created");
			using (Stream imageFileStream = File.OpenRead(imageFilePath))
			{
				//
				// Upload an image and perform OCR
				//
				Log("Calling VisionServiceClient.RecognizeTextAsync()...");
				OcrResults ocrResult = await VisionServiceClient.RecognizeTextAsync(imageFileStream, language);
				return ocrResult;
			}
			// -----------------------------------------------------------------------
			// KEY SAMPLE CODE ENDS HERE
			// -----------------------------------------------------------------------
		}
