    public FileResult GetFile(Guid id) {
        // no using block as it will be disposed of by the File method
        var amazonResponse = _foo.GetAmazonResponseWrapper(_user, id);
        return File(amazonResponse.ResponseStream, "text/plain", "bar.txt");
    }
