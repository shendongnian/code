    HttpResponseMessage respMessage;
    //note: client and request is defined elsewhere.
    respMessage = client.SendRequestAsync(request, HttpCompletionOption.ResponseHeadersRead);
    using (var responseStream = await respMessage.Content.ReadAsInputStreamAsync())
    {
       using (var fileWriteStream = await fileToStore.OpenAsync(FileAccessMode.ReadWrite))
         {
            while (streamingActive && (await responseStream.ReadAsync(streamReadBuffer, bufferLength, InputStreamOptions.None)).Length > 0)
            {
              await fileWriteStream.WriteAsync(streamReadBuffer);
           }
         }
    }
