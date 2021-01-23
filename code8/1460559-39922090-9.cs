    public class CarTreeNode : TreeNode
    {
        //  ...plus, clone all the other constructors
        public CarTreeNode(CarProperties car) :base(car.name) {
            Car = car;
        }
        private CarProperties _car;
        public CarProperties Car { 
            get { return _car; }
            set {
                _car = value;
                //  Let it throw an exception if value was null
                base.Text = Car.name;
            }
        }
    }
    ... snip ...
    //  Regrettably, TreeNodeCollection.AddRange() is an old-fashioned method 
    //  that takes an array
    treeView1.Nodes.AddRange(cars.Select(car => new CarTreeNode(car)).ToArray());
    ... snip ...
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var ctn = e.Node as CarTreeNode;
        //  In real life there's no reason you'd ever want to replace any car 
        //  that the user clicks on, but it demonstrates the principle. 
        ctn.Car = new CarProperties() { name = "Aston Martin Vanquish" };
    }
