    public partial class Arena : Form {
       private List<Drone> drones;
    
       public Arena(List<Drone> drones) {
          InitializeComponent();
          this.drones = drones;
    
          cb_drone.DataSource = drones;
          // This should be whatever the property name is in your drone class
          cb_drones.ValueMember = "DroneIp"; 
    
          // THis should be whatever the property name is 
          // in your drone class that you want to display to the user
          cb_drones.DisplayMember = "DroneSomething";
    
       }
       private void cb_drone_SelectedIndexChanged(object sender, EventArgs e) {
    
       // cb_drone.SelectedItem will give you the drone object
       // cb_drone.SelectedValue will give you the Ip (whatever you specified in ValueMember)
       var selectedDrone =  this.drones.Where(x => x.DroneIp == cb_drone.SelectedValue)
             
             //do something
       }
    }
