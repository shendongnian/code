    IEnumerator GenerateChunk()
    {
        // procedural generation
        // queue itself onto a ThreadPool
        // when done, yield
    }
    IEnumerator GenerateChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {
            StartCoroutine(GenerateChunk());
        }
        yield break;
        //Or yield return null;
    }
