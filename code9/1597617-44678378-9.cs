    using System;
    using TransitionModule;
    
    namespace FlipTransition
    {
        public class FlipTransition : AbstractTransition
        {
            public FlipTransition() : base(2)
            {
            }
    
            public override void PerformTransition()
            {
                Console.WriteLine("Performing flip transition");
            }
        }
    }
    
