    public class Foo
      {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int ID { get; set; }
          public string Name { get; set; }
       }
