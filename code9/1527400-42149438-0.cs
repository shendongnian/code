    public interface IMotorPort
    {
       Task SendData(string data);
       Task<string> RecieveData();
    }
    public class MotorPort : IMotorPort
    {
       protected SerialPort Port{get;set;}
       public Task SendData(string data)
       {
        //TODO: Send from Serial Port
       }
       public Task<string> RecieveData()
       {
        //TODO: Recieve from Serial Port
       }
     }
     public class SteeringWheelMainTelescopeMotorController
    {
       protected IMotorPort Motor{get;set;}
       public SteeringWheelMainTelescopeMotorController(IMotorPort motor)
       {
           this.Motor = motor;
        }
     }
     public class SteeringWheelTiltMotorController
     {
       protected IMotorPort Motor{get;set;}
       public SteeringWheelTiltMotorController(IMotorPort motor)
       {
          this.Motor = motor;
       }
    }
