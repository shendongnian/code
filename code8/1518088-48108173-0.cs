    public async Task<StorageFile> MergeVideoAudioAsync(StorageFile videoFile, StorageFile audioFile, string finalFileName, StorageFolder destinationFolder)
        {
            MediaComposition composition = new MediaComposition();
            var file = await destinationFolder.CreateFileAsync(finalFileName, CreationCollisionOption.GenerateUniqueName);
            var clip = await MediaClip.CreateFromFileAsync(videoFile);
            composition.Clips.Add(clip);
            var backgroundTrack = await BackgroundAudioTrack.CreateFromFileAsync(audioFile);
            composition.BackgroundAudioTracks.Add(backgroundTrack);
            await composition.RenderToFileAsync(file);
            return file;
        }
