    //using Newtonsoft.Json.Linq
    var jObject = JObject.Parse(jsonString);
    var images = jObject.Property("images").Value<JObject>(); ;
    var viewModel = new MyViewModel {
        Images = new ImagesViewModel {
            TotalCount = images.Property("totalCount").Value<int>(),
            ListImages = images.Properties().Skip(1).ToDictionary(p => p.Name, p => p.Value<ImageViewModel>())
        }
    };
