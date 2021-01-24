    public Form1()
        {
            InitializeComponent();
            Console.WriteLine("HERO STARTING LOCATION --- X = : {0} ---- Y = : {1}", pctrBxHero.Location.X, pctrBxHero.Location.Y);
            pctrBxEnemy.Location = new Point(90, 90);
        }
