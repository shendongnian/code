    public class IndexModel : PageModel
    {
        private IEnumerable<ISomething> _someThings;
        private IEnumerable<Lazy<ISomething>> _someLazyThings;
        public IndexModel(IEnumerable<ISomething> someThings,
            IEnumerable<Lazy<ISomething>> someLazyThings)
        {
            _someThings = someThings;
            _someLazyThings = someLazyThings;
        }
        public void OnGet()
        {
            List<string> names = new List<string>();
            var countSomeThings = _someThings.Count();  // 2 as expected
            var countSomeLazyThings = _someLazyThings.Count(); // 2 as expected
            foreach (var someLazyThing in _someLazyThings)
            {
                names.Add(someLazyThing.Value.Name);
            }
        }
    }
