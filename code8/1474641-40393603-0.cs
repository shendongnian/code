    var config = new MapperConfiguration(
       cfg =>
       {
          cfg.CreateMap<SessionToken, LandingModel>()
             .AfterMap((src, dest) => dest.CurrentDateTime = Common.SessionManager.GetSessionDate().ToString(SharedLib.Constants.FMT_DATE_AND_TIME_LONG));
       });
