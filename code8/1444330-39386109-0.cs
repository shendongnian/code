    private async void saveChainedEffects(StorageFile file)
	{
		var displayInformation = DisplayInformation.GetForCurrentView();
		var renderTargetBitmap = new RenderTargetBitmap();
		await renderTargetBitmap.RenderAsync(Textify.CanvasControl);
		var width = renderTargetBitmap.PixelWidth;
		var height = renderTargetBitmap.PixelHeight;
		IBuffer textBuffer = await renderTargetBitmap.GetPixelsAsync();
		byte[] pixels = textBuffer.ToArray();
		using (InMemoryRandomAccessStream memoryRas = new InMemoryRandomAccessStream())
		{
			//Encode foregroundtext to PNG
			var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, memoryRas);
			encoder.SetPixelData(BitmapPixelFormat.Bgra8,
								 BitmapAlphaMode.Straight,
								 (uint)width,
								 (uint)height,
								 displayInformation.LogicalDpi,
								 displayInformation.LogicalDpi,
								 pixels);
			await encoder.FlushAsync(); 
			IImageProvider effectBackground;
			if (SelectedEffect.Name == "No Effect")
			{
				effectBackground = imageProcessorRenderer.M_Source;
			}
			else
			{
				effectBackground = (SelectedEffect.GetEffectAsync(imageProcessorRenderer.M_Source, new Size(), new Size())).Result;
			}
			StreamImageSource streamForeground = new StreamImageSource(memoryRas.AsStream());
			//Sharpen the text
			//using (SharpnessEffect sharpnessEffect = new SharpnessEffect(streamForeground, 0.3d) )
			using (BlendEffect blendEffect = new BlendEffect(effectBackground, streamForeground, BlendFunction.Normal, 1.0f))
			using (BitmapRenderer bitmapRenderer = new BitmapRenderer(blendEffect, ColorMode.Bgra8888))
			{
			   
				Bitmap bitmap = await bitmapRenderer.RenderAsync();
				byte[] pixelBuffer = bitmap.Buffers[0].Buffer.ToArray();
				using (var stream = new InMemoryRandomAccessStream())
				{
					var pngEncoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream).AsTask().ConfigureAwait(false);
					pngEncoder.SetPixelData(BitmapPixelFormat.Bgra8, 
						BitmapAlphaMode.Straight, 
						(uint)bitmap.Dimensions.Width, 
						(uint)bitmap.Dimensions.Height, 
						displayInformation.LogicalDpi, 
						displayInformation.LogicalDpi, 
						pixelBuffer);
					await pngEncoder.FlushAsync().AsTask().ConfigureAwait(false);
					//Need an IBuffer, here is how to get one:
					using (var memoryStream = new MemoryStream())
					{
						memoryStream.Capacity = (int)stream.Size;
						var ibuffer = memoryStream.GetWindowsRuntimeBuffer();
						await stream.ReadAsync(ibuffer, (uint)stream.Size, InputStreamOptions.None).AsTask().ConfigureAwait(false);
						string errorMessage = null;
						try
						{
							using (var filestream = await file.OpenAsync(FileAccessMode.ReadWrite))
							{                                 
								await filestream.WriteAsync(ibuffer);
								await filestream.FlushAsync();
							}
						}
						catch (Exception exception)
						{
							errorMessage = exception.Message;
						}
						if (!string.IsNullOrEmpty(errorMessage))
						{
							var dialog = new MessageDialog(errorMessage);
							await dialog.ShowAsync();
						}
					}
				}                
			}
		}
	}
