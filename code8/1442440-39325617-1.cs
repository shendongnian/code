    Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    var myImageObject = new { Id = "", Images = new Dictionary<int, string>()};
    foreach(var key in dict.Keys) {
        if(key == "id") {
             myImageObject.Id = dict[key]
        }
        else {
             var imageSize = ParseForImageSize(key);
             myImageObject.Images.Add(imageSize, dict[key])
        }
    }
