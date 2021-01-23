    public class Foo
      {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int ID { get; set; }
          public string Name { get; set; }
       }
       -- here is how you can get id back 
    var context = new TestContext();
            var newFoo = new Foo{ Name = "D" };
            context.Foos.Add(newFoo);
            context.SaveChanges();
            Console.Write(newFoo.Id);
           TextBox1.Text = newFoo.Id.ToString()
