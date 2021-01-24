    internal interface IMySettings
    {
        int X { get; set; }
        int Y { get; set; }
        bool FirstRun { get; set; }
        void Save(); 
    }
