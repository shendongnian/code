    namespace ClockWise_Stackoverflow
    {
        public enum State { ClockWise, CounterClockWise, Neither }
        class Program
        {
            static void Main(string[] args)
            {
                Random rd = new Random();
                var xyInput = Enumerable.Range(0, 10)
                                            .Select(f => new double[2] 
                                                          {         
                                                           rd.NextDouble(),  
                                                           rd.NextDouble()
                                                          }
                                             .ToState())
                                             .ToList();           
            }
        }
        public static class Extension
        {
            public static State ToState(
                this double[] xy)
            {
                var x = xy[0];
                var y = xy[1];
                if (x * y <= 0) return State.Neither;
                else if (x > 0) return State.CounterClockWise;
                else if (x < 0) return State.ClockWise;
                else return State.Neither;
            }
        }
    }
