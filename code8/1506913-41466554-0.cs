    using (Stream imageFileStream = File.OpenRead(imageFilePath))
                    {
                        //
                        // Detect the emotions in the URL
                        //
                        emotionResult = await emotionServiceClient.RecognizeAsync(imageFileStream);
                        return emotionResult;
                    }
