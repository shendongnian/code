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
