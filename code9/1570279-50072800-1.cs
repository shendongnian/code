    // in DbContext
    DbSet<ModelImage> ModelImages;
    DbSet<ModelTags> ModelTags;
    DbSet<ModelImageTag> ModelImageTags;
    // your code:
    ModelImage image = ....;
    ModelTag tag = ...;
    ModelImageTag iTag = new ModelImageTag { ModelImage = image, ModelTag = tag};
    tag.Images.Add(iTag);
    image.Tags.Add(iTag);
    // tell EF to add the above objects (without this, you got nothing)...
    Context.ModelImages.Add(image);  // can also use AddRange()
    Context.ModelTags.Add(tag);
    Context.ModelImageTags.Add(iTag);
    Context.SaveChanges();
