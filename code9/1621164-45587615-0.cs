    static IEnumerable<TrainRecord> FunnyTrainFilter(IEnumerable<TrainRecord> trains)
    {
        const string steel123Name = "Steel-123";
        return trains
            .GroupBy(t => t.Train, (key, values) =>
            {
                var trainsInGroup = values.ToList();
                if (trainsInGroup.Count > 1)
                {
                    var steel = trainsInGroup.FirstOrDefault(t => t.Name == steel123Name);
                    var nonsteel = trainsInGroup.FirstOrDefault(t => t.Name != steel123Name);
                    trainsInGroup.Clear();
                    if (steel != null) trainsInGroup.Add(steel);
                    if (nonsteel != null) trainsInGroup.Add(nonsteel);
                }
                return trainsInGroup;
            })
        .SelectMany(t => t);
    }
