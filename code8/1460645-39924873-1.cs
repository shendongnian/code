    using (var connection = new SqlConnection(...))
    {
        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            // offer a message to the processing block, but allow postponement
            // in case we've hit capacity
           await processBlock.SendAsync(item);
        }
    }
