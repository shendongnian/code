    public IEnumerable<string> AllMedicationResults()
    {
        return (from t in _connection.Table<Medication>()
                select t.alarm_time).ToList();
    }
