    private HttpResponseMessage GetExceptionalResponse(Exception ex) {
        return new HttpResponseMessage {
            Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
            StatusCode = HttpStatusCode.InternalServerError
        };
    }
