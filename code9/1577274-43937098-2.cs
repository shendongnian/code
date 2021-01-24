    public static AbstractCriterion AllIn<TValue>(
        MultiValueDictionary<string, TValue> propertyNameValues)
    {
        var conj = Conjunction();
        foreach (KeyValuePair<TKey, IReadOnlyCollection<TValue>> item in propertyNameValues)
        {
            if (item.Value.Count > 1)
            {
                conj.Add(Restrictions.In(item.Key, item.Value.ToArray()));
            }
            else
            {
                conj.Add(Restrictions.Eq(item.Key, item.Value.FirstOrDefault()));
            }
        }
        return conj;
    }
