    public class myCustomModel1
    {
       public byte idL { get; set; }
       [Key]
       public int idP { get; set; }
       public string Name { get; set; }
       public virtual List<myCustomModel2> CustomModel2{ get; set; }
    }
    public class myCustomModel2
    {
       public int idData { get; set; }
    }
