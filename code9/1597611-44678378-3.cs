    namespace TransitionModule
    {
        public abstract class AbstractTransition
        {        
            public readonly int TransitionId;
            public abstract void PerformTransition();
    
            protected AbstractTransition(int transitionId)
            {
                TransitionId = transitionId;
            }
            // you can add functionality here as you see fit
        }
    }
