    public class CarTreeNode : TreeNode
    {
        //  ...plus, clone all the other constructors
        public CarTreeNode(CarProperties car) :base(car.name) {
            Car = car;
        }
        public CarProperties Car { get; set; }
    }
    ... snip ...
    //  Regrettably, TreeNodeCollection.AddRange() is an old-fashioned method 
    //  that takes an array
    treeView1.Nodes.AddRange(cars.Select(car => new CarTreeNode(car)).ToArray());
