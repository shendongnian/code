    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                //for (int i = 0; i < 1000; i++)
                //{
                //    db.Enta.Add(new Entity());
                //}
                //db.SaveChanges();
                foreach (var e in db.Enta.AsNoTracking())
                {
                    Console.WriteLine(e.Id);
                    GC.Collect();
                }
                GC.Collect();
            }
        }
    }
    public class Entity
    {
        public Entity()
        {
            Console.WriteLine("ctor");
        }
        ~Entity()
        {
            Console.WriteLine("destructor");
        }
        public int Id { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Entity> Enta { get; set; }
    }
