    public partial class Inicio : Form
    {
        private List<Drone> drones;
        private Arena arena;
        ...
    public partial class Arena : Form
    {
        private List<Drone> drones;
    
        public Arena(IEnumerable<Drone> drones)
        {
            InitializeComponent();
            drones = new List<Drone>(drones);
        }
        ...
