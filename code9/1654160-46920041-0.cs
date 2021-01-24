    Attachment attachment;
    try
    {
        attachment = new Attachment(path, mediaType);
        //Do other stuff...
    }
    catch
    {
        //Handle or log exception
    }
    finally
    {
        if (attachment != null) attachment.Dispose();
    }
