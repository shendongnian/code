    public partial class Form1 : Form
    {
        private List<Persoon> uitkomsten = new List<Persoon>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string naam = tb_naam.Text;
            string geslacht = tb_geslacht.Text;
            double gewicht = Convert.ToDouble(tb_gewicht.Text);
            double lengte = Convert.ToDouble(tb_lengte.Text);
            double bmiuitkomst = gewicht / Math.Pow(lengte / 100.0, 2);
            Persoon nieuwbmi = new Persoon(naam, geslacht, gewicht, lengte);
            rtb_uitkomst.Text = $"Naam: {naam}\r\nGeslacht: {geslacht}\r\nBMI: {bmiuitkomst}";
            uitkomsten.Add(nieuwbmi);
            lb_list.DataSource = null;
            lb_list.DataSource = uitkomsten;
        }
    }
