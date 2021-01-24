    public partial class Form1 : Form
    {
        // Todo declare the variables
        private List<string> kruidenierswList;
        private List<string> verswarenList;
        private List<string> verzproductenList;
        public Form1()
        {
            InitializeComponent();
            // call the instance once and add that to the variable lijst
            Boodschappenlijst lijst = Boodschappenlijst.Instance; // <- @ others on S/O this is just used as information I know I could do a new as well.
            // initialize the variables
            kruidenierswList = new List<string>() { lijst.Products[0], lijst.Products[1], lijst.Products[2] };
            verswarenList = new List<string>() { lijst.Products[3], lijst.Products[4], lijst.Products[5] };
            verzproductenList = new List<string>() { lijst.Products[6], lijst.Products[7], lijst.Products[8], lijst.Products[9] };
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            // populate the checklist boxes
            clbKruidenierswaren.Items.AddRange(kruidenierswList.ToArray());
            clbVerswaren.Items.AddRange(verswarenList.ToArray());
            clbVerzproducten.Items.AddRange(verzproductenList.ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new instance of the Form2 class
            Form2 form2 = new Form2();
            // Show the settings form
            form2.Show();
        }
    }
    public class Boodschappenlijst
    {
        private static Boodschappenlijst instance;
        public string[] Products
        {
            get;
            private set;
        }
        private Boodschappenlijst()
        {
            Products = new string[] { "Peper", "Zout", "Kruidnagel", "Sla", "Komkommer", "Tomaten", "Tandpasta", "Shampoo", "Wax", "Deodorant" };
        }
        public static Boodschappenlijst Instance
        {
            get
            {
                // singleton initialization => look for design pattern - singleton  <- Design patterns can brighten your day.
                // 
                return instance == null ? instance = new Boodschappenlijst() : instance;
            }
        }
    }
