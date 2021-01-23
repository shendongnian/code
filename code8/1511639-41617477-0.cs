public partial class Arena : Form
{
    private readonly Drone[] d;
    public Arena(params Drone[] d)
    {
        InitializeComponent();
        this.d = d;
    }
    private void cb_drone_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (var di in this.d)
        {
            if(cb_drone.SelectedIndex.ToString() == di.ip_drone)
            {
            //do something
            }
        }
    }
}
