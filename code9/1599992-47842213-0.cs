    var trainer = new SgdTrainer(Network) { 
                                LearningRate = Epsilon, 
                                L2Decay = Decay, 
                                Momentum = 0.9, 
                                BatchSize = TrainingSet.Count };
    for (int j = 0; j < Iterations; j++)
    {
        trainer.Train(input, 
                      new Volume(GetTrainingValues(_increment), 
                      new Shape(TrainingSet.Count)));
    }
