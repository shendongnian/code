    private static DataModel Map(DataModel _)
    {
        Data2Model model = _.Data2 ?? new Data2Model();
        return new DataModel
        {
            Id = _.Id,
            Date = _.Date,
            Data2 = new Data2Model
            {
                Id = model.Id,
                Name = model.Name,
                Date = model.Date
            }
        };
    }
