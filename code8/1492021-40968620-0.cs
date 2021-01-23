    private async void Upload_image(object sender, RoutedEventArgs e)
    {
        ImagesModel model = new ImagesModel();
        model.CategoryId = Convert.ToInt32(catgoryIdtxb.Text);
        model.IsNew = true;
        model.IsPayed = IsPayedchbx.IsChecked.Value;
        model.Name = ImageNameTxb.Text;
        model.PixelHeight = _imagePicWB.PixelHeight;
        model.PixelWidth = _imagePicWB.PixelWidth;
        model.ThumbnailPixelHeight = _imageThumWB.PixelHeight;
        model.ThumbnailPixelWidth = _imageThumWB.PixelWidth;
        model.Date = ImadeDate.Date.Date;
        using (Stream stream = _imagePicWB.PixelBuffer.AsStream())
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                model.Picture = memoryStream.ToArray();
            }
        }
        using (Stream stream = _imageThumWB.PixelBuffer.AsStream())
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                model.Thumbnail = memoryStream.ToArray();
            }
        }
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://localhost:33134/");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
        MediaTypeFormatter bsonFormatter = new BsonMediaTypeFormatter();
        HttpResponseMessage responceMessage = client.PostAsync("ApiUrl", new StringContent(
        new JavaScriptSerializer().Serialize(model), Encoding.UTF8, "application/json")).Result;
        response.EnsureSuccessStatusCode();
    }
