     var Context = new MyContext();
     ModelImage image = new ModelImage()
     {
         ModelImageId = 101,
         Tags = new List<ModelImageTag>()
     };
     ModelImage image2 = new ModelImage()
     {
         ModelImageId = 102,
         Tags = new List<ModelImageTag>()
     };
     ModelTag tag = new ModelTag()
     {
         ModelTagId = 201,
         Images = new List<ModelImageTag>()
     };
     ModelTag tag2 = new ModelTag()
     {
         ModelTagId = 202,
         Images = new List<ModelImageTag>()
     };
     ModelImageTag iTag = new ModelImageTag { ModelImage = image, ModelTag = tag };
     ModelImageTag iTag2 = new ModelImageTag { ModelImage = image, ModelTag = tag2 };
     ModelImageTag iTag3 = new ModelImageTag { ModelTag = tag, ModelImage = image2 };
     tag.Images.Add(iTag3);
     image.Tags.Add(iTag);
     image.Tags.Add(iTag2);
     Context.ModelImages.Add(image);
     Context.ModelImages.Add(image2);
     Context.ModelTags.Add(tag);
     Context.SaveChanges();
