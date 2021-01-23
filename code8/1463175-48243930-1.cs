    X509Certificate2 clientCertInRequest = Request.HttpContext.Connection.ClientCertificate;
    if (!clientCertInRequest?.Verify() || !AllowedCerialNumbers(clientCertInRequest.SerialNumber))
    {
        Response.StatusCode = 404;
        return null;
    }
