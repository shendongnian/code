    return new ObjectResult(xml)
    {
        StatusCode = (int)HttpStatusCode.Accepted,
        ContentTypes = new MediaTypeCollection { MediaTypeHeaderValue.Parse("application/xml") }
    };
