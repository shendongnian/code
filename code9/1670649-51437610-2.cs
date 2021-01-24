    //  Enable seeking
    context.Request.EnableBuffering();
    //  Read the stream as text
    var bodyAsText = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
    //  Set the position of the stream to 0 to enable rereading
    context.Request.Body.Position = 0; 
