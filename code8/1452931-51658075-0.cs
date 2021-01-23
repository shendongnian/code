    private static async Task AddFileToSounds(string uri)
		{
			// Load and add resource sound file to memory dictionary for playing
			var soundFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(uri));
			var fileInputResult = await graph.CreateFileInputNodeAsync(soundFile);
			if (AudioFileNodeCreationStatus.Success == fileInputResult.Status)
			{
				fileInputs.Add(soundFile.Name, fileInputResult.FileInputNode);
				fileInputResult.FileInputNode.Stop();
				// set volume here using outgoing gain, values 0 - 1
				fileInputResult.FileInputNode.OutgoingGain = 0.1;
				// get volume using the same property
				Debug.WriteLine("fileInputResult.FileInputNode.OutgoingGain = "+ fileInputResult.FileInputNode.OutgoingGain);
				fileInputResult.FileInputNode.AddOutgoingConnection(deviceOutput);
			}
		}
