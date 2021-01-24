    //If the size is known, use it to avoid reallocations
    use(var memStream=new MemoryStream(response.ContentLength))
    use(var responseStream=response.GetResponseStream())
    {
        //Avoid blocking while waiting for the copy with CopyToAsync instead of CopyTo
        await responseStream.CopyToAsync(memStream);
        //Reset the position
        memStream.Position = 0;
        //Use the memory stream
        ...
    }
