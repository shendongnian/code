    IDictionary<DateTime, ICollection<Action_t>> actions = new SortedDictionary<DateTime, ICollection<Action_t>>();
    void AddAction(DateTime key, Action_t action)
    {
        ICollection<Action_t> values;
        if (!actions.TryGetValue(key, out values))
        {
            values = new List<Action_t>();
            actions[key] = values;
        }
        values.Add(action);
    }
