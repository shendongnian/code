    public class MeEventArgs : EventArgs
    {
        public readonly int Action;
 
        public MeEventArgs(int actionIndex) : base()
        {
            Action = actionIndex;
        }
    }
