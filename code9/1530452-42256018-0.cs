    public void InputIntegers_Should_Be_Concatenated_When_Consider_Distinct()
    {
        var myList = CreateEnumerable(1, 2, 2, 3);
        var logic = new MainLogic();
        var result = logic.ConcatenateNumber(myList);
    }
    public IEnumerable<T> CreateEnumerable<T>(params T[] items)
    {
        return items ?? Enumerable.Empty<T>();
    }
    public class MainLogic
    {
        public string ConcatenateNumber<T>(IEnumerable<T> myList)
        {
            // do this if you want to remove nulls
            return string.Join("'", myList.Where(i => i != null).Distinct()); 
            
            //return string.Join("'", myList.Distinct()); // otherwise do this
        }
    }
