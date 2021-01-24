    ModelImage image = ....;
    ModelTag tag = ...;
    ModelImageTag iTag = new ModelImageTag { ModelImage = image, ModelTag = tag};
    tag.Images.Add(iTag);
    image.Tags.Add(iTag);
    Context.SaveChanges();
