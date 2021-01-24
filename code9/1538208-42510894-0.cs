      public interface IVerticalSpeed
      {
        int Value { get; set; }
      }
    
      public interface IFlyable
      {
        IVerticalSpeed Speed { get; set; }
      }
      
      public interface ISpeed : IVerticalSpeed
      {
        int MaxSpeed { get; set; }
      }
      
      public class Fly : IFlyable
      {
        public ISpeed Speed { get; set; }
    
        IVerticalSpeed IFlyable.Speed
        {
          get
          {
            return this.Speed;
          }
          set
          {
            // Wow, wait, you want to SET an IVerticalSpeed,
            // but not every IVerticalSpeed is an ISpeed... what now?
            // this.Speed = value;
          }
        }
      }
