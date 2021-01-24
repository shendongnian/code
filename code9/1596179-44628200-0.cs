    if (attach.PostedFile.ContentLength > 10485760) // 10MB = 10 * (2^20)
    {
        e.IsValid = false;
    }
    else
    {
        e.IsValid = true;
    }
