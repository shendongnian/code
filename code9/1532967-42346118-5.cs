    namespace WindowsFormsApplication2
    {
        public class LoopCounterArgs : EventArgs
        {
            public int Iteration { get; set; } 
    
            public LoopCounterArgs(int iteration)
            {
                Iteration = iteration;
            }
        }
    }
