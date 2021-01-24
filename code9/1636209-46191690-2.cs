    public struct Setpoint
    {
         public double Value { get; set; }
         public double Highvalue { get; set; }
         public double Lowvalue { get; set; }
         public Setpoint(double value)
         {
             Value = value;
         }
    }
    public class ControlLoop
    {
        public Setpoint Setpoint { get; set; }
    }
