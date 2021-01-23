    abstract class MyPart
    {
        private Part modelObject;
        public Part ModelObject 
        {
           get { return modelObject; }
           set { modelObject = value; }
        }
        ...
    }
    
    class MyPlate : MyPart
    {
        public new Plate ModelObject 
        {
            get { return base.ModelObject as Plate; }
            set { base.ModelObject = value; }
        public ArraList points; // from API
        ...
    }
    
    class Floor : MyPlate
    {
        ...
    }
