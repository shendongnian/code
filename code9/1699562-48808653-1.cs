    public interface IMovableObject
    {
        int GetMaxSpeed();
    }
    
    public class Car : IMovableObject
    {
        public int GetMaxSpeed()
        {
            return 100;
        }
    }
    
    public class Human : IMovableObject
    {
        public int GetMaxSpeed()
        {
            return 20;
        }
    }
    public static class SpeedChecker
    {
        public static void CheckSpeed(IMovableObject speedster)
        {
            Console.WriteLine("Checking Speed..");
    
            int speed = speedster.GetMaxSpeed();
            if (speed > 50)
                Console.WriteLine("It's really fast!");
            else
                Console.WriteLine("Just a turtle or something similar...");
        }
    }
