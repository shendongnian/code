    public class Field
    {
        /*Your properties here*/
    }
    public class Row
    {
        public List<Field> field { get; set; }
    }
    
    public class Resultset
    {
        public List<Row> row { get; set; }
    }
    
    public class RootObject
    {
        public Resultset resultset { get; set; }
    }
