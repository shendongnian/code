    //Use convention or annotations
    //convention naming for foreign key
    public partial class Childs
    {
        public int IdChild { get; set; }
        //public int IdParent { get; set; }
        public int ParentsID {get; set;}// <---
        public string Description { get; set; }
    
        public virtual Parents Parents { get; set; }
    }
