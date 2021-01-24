    private void Analyze()
    {
      if (!_naturalLanguageUnderstanding.Analyze(OnAnalyze, OnFail, <parameters>))
          Log.Debug("ExampleNaturalLanguageUnderstanding.Analyze()", "Failed to get models.");
    }
    private void OnAnalyze(AnalysisResults resp, Dictionary<string, object> customData)
    {
        Log.Debug("ExampleNaturalLanguageUnderstanding.OnAnalyze()", "AnalysisResults: {0}", customData["json"].ToString());
    }
