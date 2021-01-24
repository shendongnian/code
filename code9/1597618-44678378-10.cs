    using System;
    using TransitionModule;
    
    namespace SlideTransition
    {
        public class SlideTransition : AbstractTransition
        {
            public SlideTransition() : base(1)
            {
            }
    
            public override void PerformTransition()
            {
                Console.WriteLine("Performing slide transition");
            }
        }
    }
    
