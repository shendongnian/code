    public Form1()
    {
        InitializeComponent();
        //  Horrible example code -- in real life you'd have a method for this
        foreach (var car in cars)
        {
            var tn = new TreeNode(car.name)
            {
                Tag = car
            };
            treeView1.Nodes.Add(tn);
        }
    }
    public List<CarProperties> cars = new List<CarProperties>()
    {
        new CarProperties() { name = "Ford Focus" },
        new CarProperties() { name = "TVR Tamora" },
        new CarProperties() { name = "Toyota Tacoma" },
    };
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var car = e.Node.Tag as CarProperties;
        ;
    }
