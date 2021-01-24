    public interface IListOfAnything
        {
            List<Species> ListOfSpecies { get; set; }
            List<Chemical> ListOfChemical { get; set; }
            // List<SomeNewitem> ListOfSomeNewitem { get; set; }
        }
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public IListOfAnything data { get; set; }/*here you get list both type of model */
        public int recordsTotal { get; set; }
    }
