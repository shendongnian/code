    interface IEvaluator
    {
        IClientReceiveRecorder { get; set; }
        void Evaluate();
    }
