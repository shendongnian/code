    static IEnumerable<TrainRecord> FunnyTrainFilter(IEnumerable<TrainRecord> trains)
    {
        const string steel123Name = "Steel-123";
        return trains
            .GroupBy(t => t.Train, (key, values) =>
            {
                var trainsInGroup = values.ToList();
                TrainRecord result;
                if (trainsInGroup.Count > 1)
                {
                    var steel = trainsInGroup.FirstOrDefault(t => t.Name == steel123Name);
                    var nonsteel = trainsInGroup.FirstOrDefault(t => t.Name != steel123Name);
                    result = new TrainRecord
                    {
                        Train = key,
                        Manufacturer = nonsteel?.Manufacturer,
                        Model = nonsteel?.Model,
                        Type = steel?.Type,
                        Name = steel?.Name,
                        EnableQuery = trainsInGroup.Sum(t => t.EnableQuery)
                   };
                }
                else
                    result = trainsInGroup[0];
                return result;
            });
    }
