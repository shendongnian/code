public partial class Inicio : Form
{
    private List<Drone> d;
    private Arena arena;
    public Inicio()
    {
        InitializeComponent();         
    }
    private void btnconetar_Click(object sender, EventArgs e)
    {
        d = new List<Drone>(){ new Drone("192.168.1.10"), /* whatever */ };
        arena = new Arena(d.ToArray());
        arena.Show();
        this.Hide(); 
    }
}
