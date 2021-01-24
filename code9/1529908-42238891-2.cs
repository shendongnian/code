    private static async Task WriteFileAsync(ActionContext context, FileStreamResult result)
    {
        var response = context.HttpContext.Response;
        var outputStream = response.Body;
        using (result.FileStream)
        {
            await result.FileStream.CopyToAsync(outputStream, BufferSize);
        }
    }
