    private void OnMessage(object resp, string customData)
    {
        Dictionary<string, object> respDict = resp as Dictionary<string, object>;
        object intents;
        respDict.TryGetValue("intents", out intents);
        foreach(var intentObj in (intents as List<object>))
        {
            Dictionary<string, object> intentDict = intentObj as Dictionary<string, object>;
            object intentString;
            intentDict.TryGetValue("intent", out intentString);
            object confidenceString;
            intentDict.TryGetValue("confidence", out confidenceString);
            Log.Debug("ExampleConversation", "intent: {0} | confidence {1}", intentString.ToString(), confidenceString.ToString());
        }
    }
