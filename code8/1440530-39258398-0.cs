    public static APIResult GetRealTimePrediction(Dictionary<string, string> Data, string PayloadJSON = null) {
            AmazonMachineLearningConfig MLConfig = new AmazonMachineLearningConfig();
            MLConfig.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
            MLConfig.Validate(); // Just in case, not really needed
            
            AmazonMachineLearningClient MLClient = new AmazonMachineLearningClient("xxx", "xxx", MLConfig);
            
            Amazon.MachineLearning.Util.RealtimePredictor RTP = new Amazon.MachineLearning.Util.RealtimePredictor(MLClient, "xxx");
            Prediction P = RTP.Predict(Data);
    }
