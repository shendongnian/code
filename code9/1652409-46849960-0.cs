    interface IAnalyzer
    {
        string Description { get; }         // this is what user will see as the action name
        Result Perform(SomeObject input);
    }
