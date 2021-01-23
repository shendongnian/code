public partial class Inicio : Form
{
    private Drone d1,d2;
    private Arena arena;
    public Inicio()
    {
        InitializeComponent();         
    }
    private void btnconetar_Click(object sender, EventArgs e)
    {
        d1 = new Drone("192.168.1.10");
        d2 = new Drone("192.168.1.20");
        ....
        dn = new Drone("192.168.1.xx");
        arena = new Arena(d1,d2);
        arena.Show();
        this.Hide(); 
    }
}
