    //Your form code/class
    class SpotForm
    {
        private dbConnect dbConnection = new dbConnect(); //Database connection
        private List<Spot> listSpots = new List<Spot>(); //Local list
     
        // Constructor
        public SpotForm()
        {
            listSpots = dbConnection.getSpots();
        }
