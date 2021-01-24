    public partial class Form1 : Form
    {
        private List<Food> foodSource();
        public Form1()
        {
            InitializeComponent();
            initFood();
        }
    
        private void initFood()
        {
            this.foodSource = new List<Food>();
    
            this.foodSource.Add(new Food { name = "Pizza", price = 10 });
            this.foodSource.Add(new Food { name = "Burger", price = 15 });
            this.foodSource.Add(new Food { name = "Chips", price = 5 });
            this.menu.DataSource = foodSource;
            menu.DisplayMember = "name";
        }
    }
