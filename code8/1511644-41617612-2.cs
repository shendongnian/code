    public partial class Inicio : Form {
    
       private List<Drone> drones;
       private Arena arena;
    
    
       public Inicio() {
          InitializeComponent();
          this.drones = new List<Drone>();
       }
    
       private void btnconetar_Click(object sender, EventArgs e) {
          d1 = new Drone( "192.168.1.10" );
          d2 = new Drone( "192.168.1.20" );
          drones.Add( d1 );
          drones.Add( d2 );
          // more drones
    
          arena = new Arena( drones );
    
          arena.Show();
    
          this.Hide();
       }
    }
    
