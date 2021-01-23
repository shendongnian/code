    public enum BuildingType
    {
        House,
        Apartment,
        Condo
        //etc
    }
    
    public interface IHousing
    {
        int SquareFootage { get; set; }
        int YearBuilt { get; set; }
        int ZipCode { get; set; }
        int MaximumOccupants { get; set; }    
        int MortgageAmount { get; }    
        int RentalIncome { get; } 
        BuildingType BuildingType { get; }
    }
    public class MultiPersonHouse 
        : IHousing
    {
        public int SquareFootage { get; set; }
        public int YearBuilt { get; set; }
        public int ZipCode { get; set; }
        public int MaximumOccupants { get; set; }
    
        public int MortgageAmount { get; private set; }    
        public int RentalIncome { get; private set;} 
        public BuildingType BuildingType { get; private set;}
    
        public MultiPersonHouse(int squareFootage, int yearBuilt /*etc...*/)
        {
            //set properties.
            this.BuildingType = BuildingType.House;
            this.MortgageAmount = 0; //Free!
            this.RentalIncome = 0; //Free rent too!
        }
    }
