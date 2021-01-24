    class Square : Rectangle {
        public override double Width {
            get { return base.Width; }
            set { 
                base.Width = value; 
                base.Height = value;
            }
        }
        
        public override double Height {
            get { return base.Height; }
            set { 
                base.Width = value; 
                base.Height = value;
            }
        }
        
        public double Edge {
            get { return Width; }
            set {
                base.Width = value; 
                base.Height = value;
            }
        }
        
        public Square(double edge) : base(edge, edge) {
            
        }
    }
