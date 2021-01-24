    public override string GetLocalFileName(HttpContentHeaders headers)
    {
        string prefix = "Nor" + DateTime.Now.ToString("yyyyMMddHHmmss");
        if (headers != null && headers.ContentDisposition != null)
        {
            var filename = headers.ContentDisposition.FileName.Trim('"');
            return prefix + filename;
        }
        return base.GetLocalFileName(headers);
    }
