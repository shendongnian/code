    using System.ComponentModel.DataAnnotations.Schema;
    public class MyModel
    {
        public int ParentLocationID {get; set;}
        public int ChildLocationID {get; set;}
    
        [ForeignKey("ParentLocationID")]
        public Location Location1 {get; set;}
        [ForeignKey("ChildLocationID")]
        public Location Location2 {get; set;}
    } 
