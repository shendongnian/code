    public Task<IActionResult> RealTimeAsync() {
        var StatusMessage = string.Empty;
        try {
            var request = this.Request;
            var doc = new XmlDocument();
            doc.Load(request.Body); //request.Body returns a stream
        //...other code...
