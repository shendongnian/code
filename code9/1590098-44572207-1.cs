    //SVM Settings
        var teacher = new MulticlassSupportVectorLearning<Linear, Sparse<double>>()
        {
            Learner = (p) => new SequentialMinimalOptimization<Linear, Sparse<double>>()
            {
                CacheSize = 1000
                Complexity = 1,
            }
        };
        var inputs = allTerms.Select(t => new Sparse<double>(t.Sentence.Select(s => s.Index).ToArray(), t.Sentence.Select(s => (double)s.Value).ToArray())).ToArray();
        var classes = allTerms.Select(t => t.Class).ToArray();
        //Train the model
        var model = teacher.Learn(inputs, classes);
