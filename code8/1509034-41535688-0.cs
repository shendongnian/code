    private VisualRecognition m_VisualRecognition = new VisualRecognition();
    
    void Start()
    {
        string m_positiveExamplesPath = Application.dataPath + "/testData/cpu_positive_examples.zip";
        string m_negativeExamplesPath = Application.dataPath + "/testData/negative_examples.zip";
    
        Dictionary<string, string> positiveExamples = new Dictionary<string, string>();
        positiveExamples.Add("giraffe", m_positiveExamplesPath);
    
        if (!m_VisualRecognition.TrainClassifier(OnTrainClassifier, "unity-test-classifier-example", positiveExamples, m_negativeExamplesPath))
            Log.Debug("ExampleVisualRecognition", "Train classifier failed!");
    }
    
    private void OnTrainClassifier(GetClassifiersPerClassifierVerbose classifier, string data)
    {
    
        if (classifier != null)
        {
            Log.Debug("ExampleVisualRecognition", "Classifier is training! " + classifier);
        }
        else
        {
            Log.Debug("ExampleVisualRecognition", "Failed to train classifier!");
        }
    }
