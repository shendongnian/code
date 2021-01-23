    	if (fileSize.MegaBytes > 4)
						{
							var session = await graphClient.Drive.Root.ItemWithPath(uploadPath).CreateUploadSession().Request().PostAsync();
							var maxSizeChunk = 320 * 4 * 1024;
							var provider = new ChunkedUploadProvider(session, graphClient, stream, maxSizeChunk);
							var chunckRequests = provider.GetUploadChunkRequests();
							var exceptions = new List<Exception>();
							var readBuffer = new byte[maxSizeChunk];
							DriveItem itemResult = null;
							//upload the chunks
							foreach (var request in chunckRequests)
							{
								// Do your updates here: update progress bar, etc.
								// ...
								// Send chunk request
								var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, exceptions);
								if (result.UploadSucceeded)
								{
									itemResult = result.ItemResponse;
								}
							}
							// Check that upload succeeded
							if (itemResult == null)
							{
								await UploadFilesToOneDrive(fileName, filePath, graphClient);
							}
						}
						else
						{
							await graphClient.Drive.Root.ItemWithPath(uploadPath).Content.Request().PutAsync<DriveItem>(stream);
						}
