    public class Drone {
       public System.Windows.Point Position { get; set; }
       public Rectangle SafeArea { get; set; }
       public bool CheckIfDroneWithinMySafeArea(Drone drone) {
       return this.SafeArea.Contains( drone.Position );
       }
    }
