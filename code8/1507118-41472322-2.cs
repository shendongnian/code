    public class SelectorViewModel
    {
        public static SelectorViewModel GetSelectorViewModel<T>(T input)
        {
            //create SelectorViewModel how do you prefer
            return new SelectorViewModel(input.Id, input.Description, input.Code);
        }
        public SelectorViewModel(int id, string description, int code)
        {
            // TODO
        }
    }
    public IEnumerable<SelectorViewModel> Selector<T>(Func<T, SelectorViewModel> factoryMethod)
    {
         var result = session.Query<T>
                     .Where(x => .... )
                     .OrderBy(x => ... )
                     .Select(x => factoryMethod(x))
                     .ToList();
         return result;
    }
