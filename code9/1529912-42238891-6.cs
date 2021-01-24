    protected static async Task WriteFileAsync(HttpContext context, Stream fileStream, RangeItemHeaderValue range, long rangeLength)
    {
        var outputStream = context.Response.Body;
        using (fileStream)
        {
            try
            {
                if (range == null)
                {
                    await StreamCopyOperation.CopyToAsync(fileStream, outputStream, count: null, bufferSize: BufferSize, cancel: context.RequestAborted);
                }
                else
                {
                    fileStream.Seek(range.From.Value, SeekOrigin.Begin);
                    await StreamCopyOperation.CopyToAsync(fileStream, outputStream, rangeLength, BufferSize, context.RequestAborted);
                }
            }
            catch (OperationCanceledException)
            {
                // Don't throw this exception, it's most likely caused by the client disconnecting.
                // However, if it was cancelled for any other reason we need to prevent empty responses.
                context.Abort();
            }
        }
    }
