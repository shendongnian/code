    IZendeskClient client = new ZendeskClient(
        new Uri(model.RequestUri),
        new ZendeskDefaultConfiguration(model.Username,
                model.Password)
    );
    UploadRequest request = new UploadRequest() {
        Item = model.Attachment.ConvertToZendeskFile()
    };
    IResponse<Upload> response = client.Upload.Post(request);
    return response.Item.Token;
