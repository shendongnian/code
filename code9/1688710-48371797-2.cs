    public struct MyRectangle
    {
        private readonly bool isNotDefault;
 
        public MyRectangle(double w, double l)
        {
            isNotDefault = true;
            width = w;
            length = l;
        }
        public double Area()
        {
            //Notice the use of the properties,
            //not the backing fields.
            return Width * Length;             
        }
        private readonly double width, length;
        public double Width => isNotDefault ? width: 1;
        public double Length => isNotDefault ? length : 1;
        public override string ToString()
            => $"Width: {Width} Lenght: {Length}";
    }
