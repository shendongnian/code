    private VisualRecognition m_VisualRecognition = new VisualRecognition();
    void Start()
    {
        string positiveExamplesPath = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/visual-recognition-classifiers/giraffe_positive_examples.zip";
        string negativeExamplesPath = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/visual-recognition-classifiers/negative_examples.zip";
        Dictionary<string, string> positiveExamples = new Dictionary<string, string>();
        positiveExamples.Add("giraffe", positiveExamplesPath);
        if (!m_VisualRecognition.TrainClassifier(OnTrainClassifier, "unity-test-classifier-example", positiveExamples, negativeExamplesPath))
            Debug.Log("Train classifier failed!");
    }
    private void OnTrainClassifier(GetClassifiersPerClassifierVerbose classifier, string data)
    {
        if (classifier != null)
        {
            Debug.Log("Classifier is training! " + classifier);
        }
        else
        {
            Debug.Log("Failed to train classifier!" + data);
        }
    }
