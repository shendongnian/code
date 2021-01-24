    private async Task SaveChunk(DataChunkSaver chunk, IProgress<string> progress)
    {
        int i = 0;
        int step = 10;
        while (chunk.saveChunk(i, step))
        {
            i += step;
            progress?.Report(chunk.Log); // Always use progress as if it could be null!
        }
    }
