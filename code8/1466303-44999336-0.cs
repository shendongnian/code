    /// <summary>
    ///   Creates a nearest neighbor algorithm with the feature points as
    ///   inputs and their respective indices a the corresponding output.
    /// </summary>
    /// 
    protected virtual IMulticlassScoreClassifier<T> CreateNeighbors(T[] features)
    {
        int[] outputs = Vector.Range(0, features.Length);
        // Create a k-Nearest Neighbor classifier to classify points
        // in the second image to nearest points in the first image
        return new KNearestNeighbors<T>(K, Distance).Learn(features, outputs);
    }
