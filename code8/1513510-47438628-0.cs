    var cont = new MultipartFormDataContent();
    var image = new StreamContent(img.Image.GetStream());
    cont.Add(image, "\"file\"", img.FileName);
    var uri = App.apiurl + $"FileUpload/" + img.FileName + "/";
    using (var client = new HttpClient())
    {
        var response = await client.PostAsync(uri, cont);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            // return error code
        }
        
    }
