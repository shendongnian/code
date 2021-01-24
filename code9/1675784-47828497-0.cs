      class Program
      {
         public class Book
         {
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime Release { get; set; }
         }
         static void Main(string[] args)
         {
            var b = new Book()
            {
               Title = "A",
               Release = DateTime.Now,
            };
            var res = Extend(
               new ExpandoObject(), // fills in new object
               b, // adds in book properties that are not null
               new { Author = "X" }, // sets Author from anonymous type
               new { NotExist = 1 }); // if target type is no Expando (eg. Book) and tries to set property that doesn't exist, just ignore it
         }
         public static dynamic Extend(dynamic destination, params dynamic[] add)
         {
            foreach (dynamic item in add)
            {
               var names = Dynamitey.Dynamic.GetMemberNames(item);
               foreach (var name in names)
               {
                  var value = Dynamic.InvokeGet(item, name);
                  if (value != null)
                  {
                     try
                     {
                        Dynamic.InvokeSet(destination, name, value);
                     }
                     catch (RuntimeBinderException)
                     {
                        // no available TryInvokeSet method, so hacking it like this..
                     }
                  }
               }
            }
            return destination;
         }
      }
