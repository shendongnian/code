    class Foo : IEquatable<Foo>
    {
        public int ID;
        public string Description;
        public long Location;
        public bool Equals(Foo other)
        {
            // Whatever your logic is
            return string.IsNullOrEmpty(this.Description) == string.IsNullOrEmpty(other.Description) && 
                   this.ID > 0 == other.ID > 0 && 
                   this.Location > 0 == other.Location > 0;
        }
    }
    public class Home : Controller
    {
        public ActionResult FilteredFooList(Foo filterObj)
        {
            List<Foo> filteredFooList = fooList.Where(f => f.Equals(filterObj));
        }
    }
