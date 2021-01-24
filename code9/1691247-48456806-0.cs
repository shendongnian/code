    void Main()
    {
    	var speciesDataTableRequest = new DataTableRequest<Species>();
    	var chemicalsDataTableRequest = new DataTableRequest<Chemical>();
    }
    
    // Define other methods and classes here
    public class DataTableRequest<T>
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }    
        public List<T> data { get; set; }/*any type now*/
        public int recordsTotal { get; set; }
    }
    
    public partial class Species
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
    }
    
    public partial class Chemical
    {
        public int ChemicalId { get; set; }
        public string ChemicalName { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
    }
