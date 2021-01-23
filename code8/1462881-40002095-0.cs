    static bool TryCastAsList<T>(object input, out IList<T> output)
    {
        IEnumerable inputAsIEnumerable = input as IEnumerable;
        if (inputAsIEnumerable != null)
        {
            output = inputAsIEnumerable.Cast<T>().ToList();
            return true;
        }
        else
        {
            output = null;
            return false;
        }
    }
