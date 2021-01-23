    public partial class Form1 : Form {
        public decimal level { get; set; }
        public decimal money { get; set; }
        public decimal revenue { get; set; }
        public decimal multiplier { get; set; }
        public decimal price { get; set; }
        private Timer Updater { get; set; }
        public Form1() {
            InitializeComponent();
            Updater = new Timer();
            Start();
        }
        void Start() {
            money = 10;
            multiplier = 1.10m;
            price = 5;
            label1.Text = "Level: " + money.ToString();
            label3.Text = "Revenue: " + revenue.ToString();
            button1.Text = "Price: " + price.ToString();
            label4.Text = "Money: " + money.ToString();
            Updater.Interval = 1000; //interval in milliseconds || this will tick every second
            Updater.Tick += Updater_Tick;
            Updater.Start();
        }
        private void Updater_Tick(object sender, EventArgs e) {
                money += revenue;
            label4.Text = "Money: " + money.ToString();
            
            
        }
        
        void button1_Click(object sender, EventArgs e) {
            if (money >= price) {
                money -= price;
                price = ((price/100)*150m);
                button1.Text = "Price: " + price.ToString();
                level++;
                label1.Text = "Level: " + money.ToString();
                label3.Text = "Revenue: " + revenue.ToString();
                revenue = level*multiplier;
                
                textBox1.Text = "Item Bought";
            }
        }
    }
