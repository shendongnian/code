    // Ensure results are reproducible
    Accord.Math.Random.Generator.Seed = 0;
    
    // The Bag-of-Visual-Words model converts images of arbitrary 
    // size into fixed-length feature vectors. In this example, we
    // will be setting the codebook size to 3. This means all feature
    // vectors that will be generated will have the same length of 3.
    
    // By default, the BoW object will use the sparse SURF as the 
    // feature extractor and K-means as the clustering algorithm.
    // In this example, we will use the Haralick feature extractor.
    
    // Create a new Bag-of-Visual-Words (BoW) model using Haralick features
    var bow = BagOfVisualWords.Create(new Haralick()
    {
        CellSize = 256, // divide images in cells of 256x256 pixels
        Mode = HaralickMode.AverageWithRange,
    }, new KMeans(3));
    
    // Generate some training images. Haralick is best for classifying
    // textures, so we will be generating examples of wood and clouds:
    var woodenGenerator = new WoodTexture();
    var cloudsGenerator = new CloudsTexture();
    
    Bitmap[] images = new[]
    {
        woodenGenerator.Generate(512, 512).ToBitmap(),
        woodenGenerator.Generate(512, 512).ToBitmap(),
        woodenGenerator.Generate(512, 512).ToBitmap(),
    
        cloudsGenerator.Generate(512, 512).ToBitmap(),
        cloudsGenerator.Generate(512, 512).ToBitmap(),
        cloudsGenerator.Generate(512, 512).ToBitmap()
    };
    
    // Compute the model
    bow.Learn(images);
    
    bow.ParallelOptions.MaxDegreeOfParallelism = 1;
    
    // After this point, we will be able to translate
    // images into double[] feature vectors using
    double[][] features = bow.Transform(images);
