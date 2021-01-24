    public struct Setpoint
    {
         public double Value { get; set; }
         public double Highvalue { get; set; }
         public double Lowvalue { get; set; }
         public Setpoint(double value)
         {
             Value = value;
             Highvalue = 0;
             Lowvalue = 0;
         }
    }
    public class ControlLoop
    {
        public Setpoint Setpoint { get; set; }
    }
