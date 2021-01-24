    IDictionary<string, object> parameters = new Dictionary<string, object>();
    parameters.Add("CommandParameter", interaction);
    parameters.Add("Reasons", reasons);
    parameters.Add("Extensions", extensions);
    commandManager.GetChainOfCommandByName("InteractionVoiceReleaseCall").Execute();
