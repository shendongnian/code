    // Now, the features can be used to train any classification
    // algorithm as if they were the images themselves. For example,
    // let's assume the first three images belong to a class and
    // the second three to another class. We can train an SVM using
    
    int[] labels = { -1, -1, -1, +1, +1, +1 };
    
    // Create the SMO algorithm to learn a Linear kernel SVM
    var teacher = new SequentialMinimalOptimization<Linear>()
    {
        Complexity = 100 // make a hard margin SVM
    };
    
    // Obtain a learned machine
    var svm = teacher.Learn(features, labels);
    
    // Use the machine to classify the features
    bool[] output = svm.Decide(features);
    
    // Compute the error between the expected and predicted labels
    double error = new ZeroOneLoss(labels).Loss(output); // should be 0
