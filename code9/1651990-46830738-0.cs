        var labels =
            CNTKLib.InputVariable(new int[] {_classesNumber}, DataType.Float, _labelNa
        Variable input;
        Function model;
        if (File.Exists(_modelFile))
        {
            model = Function.Load(_modelFile, DeviceDescriptor.GPUDevice(0));
            input = model.Arguments.Single(a => a.Name == _featureName);
        }
        else
        {
            input = CNTKLib.InputVariable(_imageDimension, DataType.Float, _featureName);
            model = BuildNetwork(input);
        }
        var trainer = CreateTrainer(model, labels);
        IList<StreamConfiguration> streamConfigurations = new StreamConfiguration[]
        {
            new StreamConfiguration(_featureName, _imageSize), 
            new StreamConfiguration(_labelName, _classesNumber)
        };
        var minibatchSource = MinibatchSource.TextFormatMinibatchSource(
            Path.Combine(_ressourceFolder, _trainingDataFile),
            streamConfigurations,
            MinibatchSource.InfinitelyRepeat);
        TrainModel(minibatchSource, trainer, labels, input);
