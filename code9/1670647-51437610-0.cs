    var body = new System.IO.MemoryStream();
    await context.Request.Body.CopyToAsync(body);
    
    body.Position = 0;
    var bodyText = await new System.IO.StreamReader(body).ReadToEndAsync();
    
    body.Position = 0;
    context.Request.Body = body;
