    [HttpGet("getbars")]
    public async Task<string> GetBarsAsync([FromHeader] Guid CorrelationId, int Count)
    {
        Logger.Log(CorrelationId, $"Creating {Count} foo bars.");
        StringBuilder stringBuilder = new StringBuilder();
        for (int count = 0; count < Count; count++)
        {
            stringBuilder.Append("Bar! ");
        }
        return await Task.FromResult(stringBuilder.ToString());
    }
