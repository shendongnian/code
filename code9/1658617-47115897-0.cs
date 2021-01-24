    public static Expression<Func<TripLanguage,TripViewModel>> ToSearchModel(ILookup<int, TagViewModel> tags = null) {
        return tripLanguage => new TripViewModel() {
            From = tripLanguage.From,
            To = tripLanguage.To,
            Annotation = tripLanguage.Description.Truncate(Strings.TRUNCATE_ANOTATION),
            Level = tripLanguage.Trip.Level,
            BicycleType = tripLanguage.Trip.BicycleType,
            UrlId = tripLanguage.UrlId,
            Distance = tripLanguage.Trip.Distance,
            Tags = tags?[tripLanguage.TripId], // <<== Note the question mark
            MainImage = tripLanguage.Trip.Images.OrderBy(s => s.Date).Select(i => new ImageViewModel
            {
                Filename = i.Filename,
                Id = i.Id,
                Title = i.Title
            }).Take(1)
        };
    }
