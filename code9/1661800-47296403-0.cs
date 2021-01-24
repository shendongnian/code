    public double CalculatePredictedRSquared()
    {
        Vector<double> output = whatever;
        // Whatever other state you need here
        IEnumerable<int> range = Enumerable.Range(0, output.Count);
        IEnumerable<double> query = 
          range.Select(i => DoIt(i, whatever_other_state));
        return query.Sum();
    }
